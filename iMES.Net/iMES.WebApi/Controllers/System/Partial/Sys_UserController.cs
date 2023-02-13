
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using iMES.Core.CacheManager;
using iMES.Core.Configuration;
using iMES.Core.Controllers.Basic;
using iMES.Core.DBManager;
using iMES.Core.EFDbContext;
using iMES.Core.Enums;
using iMES.Core.Extensions;
using iMES.Core.Filters;
using iMES.Core.Infrastructure;
using iMES.Core.ManageUser;
using iMES.Core.ObjectActionValidator;
using iMES.Core.Services;
using iMES.Core.Utilities;
using iMES.Entity.AttributeManager;
using iMES.Entity.DomainModels;
using iMES.System.IRepositories;
using iMES.System.IServices;
using iMES.System.Repositories;
using iMES.System.Services;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System.Collections.Generic;

namespace iMES.System.Controllers
{
    [Route("api/User")]
    public partial class Sys_UserController
    {
        private ISys_UserRepository _userRepository;
        private ICacheService _cache;
        [ActivatorUtilitiesConstructor]
        public Sys_UserController(
               ISys_UserService userService,
               ISys_UserRepository userRepository,
               ICacheService cahce
              )
          : base(userService)
        {
            _userRepository = userRepository;
            _cache = cahce;
        }

        [HttpPost, HttpGet, Route("login"), AllowAnonymous]
        [ObjectModelValidatorFilter(ValidatorModel.Login)]
        public async Task<IActionResult> Login([FromBody] LoginInfo loginInfo)
        {
            return Json(await Service.Login(loginInfo));
        }
        //后台App_ProductController中添加代码，返回table数据
        [HttpPost, Route("getSelectorDemo")]
        public IActionResult GetSelectorDemo([FromBody] PageDataOptions options)
        {
            //1.可以直接调用框架的GetPageData查询
            PageGridData<Sys_User> data = Sys_UserService.Instance.GetPageData(options);
            return JsonNormal(data);
        }
        private readonly ConcurrentDictionary<int, object> _lockCurrent = new ConcurrentDictionary<int, object>();
        [HttpPost, Route("replaceToken")]
        public IActionResult ReplaceToken()
        {
            WebResponseContent responseContent = new WebResponseContent();
            string error = "";
            string key = $"rp:Token:{UserContext.Current.UserId}";
            UserInfo userInfo = null;
            try
            {
                //如果5秒内替换过token,直接使用最新的token(防止一个页面多个并发请求同时替换token导致token错位)
                if (_cache.Exists(key))
                {
                    return Json(responseContent.OK(null, _cache.Get(key)));
                }
                var _obj = _lockCurrent.GetOrAdd(UserContext.Current.UserId, new object() { });
                lock (_obj)
                {
                    if (_cache.Exists(key))
                    {
                        return Json(responseContent.OK(null, _cache.Get(key)));
                    }
                    string requestToken = HttpContext.Request.Headers[AppSetting.TokenHeaderName];
                    requestToken = requestToken?.Replace("Bearer ", "");

                    if (JwtHelper.IsExp(requestToken)) return Json(responseContent.Error("Token已过期!"));

                    int userId = UserContext.Current.UserId;

                    userInfo = _userRepository.FindAsIQueryable(x => x.User_Id == userId).Select(
                             s => new UserInfo()
                             {
                                 User_Id = userId,
                                 UserName = s.UserName,
                                 UserTrueName = s.UserTrueName,
                                 Role_Id = s.Role_Id,
                                 RoleName = s.RoleName
                             }).FirstOrDefault();

                    if (userInfo == null) return Json(responseContent.Error("未查到用户信息!"));

                    string token = JwtHelper.IssueJwt(userInfo);
                    //移除当前缓存
                    _cache.Remove(userId.GetUserIdKey());
                    //只更新的token字段
                    _userRepository.Update(new Sys_User() { User_Id = userId, Token = token }, x => x.Token, true);
                    //添加一个5秒缓存
                    _cache.Add(key, token, 5);
                    responseContent.OK(null, token);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message + ex.StackTrace;
                responseContent.Error("token替换异常");
            }
            finally
            {
                _lockCurrent.TryRemove(UserContext.Current.UserId, out object val);
                string _message = $"用户{userInfo?.User_Id}_{userInfo?.UserTrueName},({(responseContent.Status ? "token替换成功": "token替换失败")})";
                Logger.Info(LoggerType.ReplaceToeken, _message, null, error);
            }
            return Json(responseContent);
        }


        [HttpPost, Route("modifyPwd")]
        [ApiActionPermission]
        //通过ObjectGeneralValidatorFilter校验参数，不再需要if esle判断OldPwd与NewPwd参数
        [ObjectGeneralValidatorFilter(ValidatorGeneral.OldPwd, ValidatorGeneral.NewPwd)]
        public async Task<IActionResult> ModifyPwd(string oldPwd, string newPwd)
        {
            return Json(await Service.ModifyPwd(oldPwd, newPwd));
        }

        [HttpPost, Route("getCurrentUserInfo")]
        public async Task<IActionResult> GetCurrentUserInfo()
        {
            return Json(await Service.GetCurrentUserInfo());
        }

        //只能超级管理员才能修改密码
        //2020.08.01增加修改密码功能
        [HttpPost, Route("modifyUserPwd"), ApiActionPermission(ActionRolePermission.SuperAdmin)]
        public IActionResult ModifyUserPwd(string password, string userName)
        {
            WebResponseContent webResponse = new WebResponseContent();
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userName))
            {
                return Json(webResponse.Error("参数不完整"));
            }
            if (password.Length < 6) return Json(webResponse.Error("密码长度不能少于6位"));

            ISys_UserRepository repository = Sys_UserRepository.Instance;
            Sys_User user = repository.FindFirst(x => x.UserName == userName);
            if (user == null)
            {
                return Json(webResponse.Error("用户不存在"));
            }
            user.UserPwd = password.EncryptDES(AppSetting.Secret.User);
            repository.Update(user, x => new { x.UserPwd }, true);
            //如果用户在线，强制下线
            UserContext.Current.LogOut(user.User_Id);
            return Json(webResponse.OK("密码修改成功"));
        }

        /// <summary>
        /// 2020.06.15增加登陆验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("getVierificationCode"), AllowAnonymous]
        public IActionResult GetVierificationCode()
        {
            string code = VierificationCode.RandomText();
            var data = new
            {
                img = VierificationCode.CreateBase64Imgage(code),
                uuid = Guid.NewGuid()
            };
            HttpContext.GetService<IMemoryCache>().Set(data.uuid.ToString(), code, new TimeSpan(0, 5, 0));
            return Json(data);
        }
        /// <summary>
        /// 导出PDF
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("ExportPDF")]
        [Obsolete]
        public string ExportPDF()
        {
            var titleStyle = TextStyle.Default.FontSize(36).SemiBold().FontColor(Colors.Blue.Medium);
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            string path_file = AppSetting.GetSettingString("ExportPDFPath") + @"\User\" + fileName;
            //整合对象
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    //字体默认大小20号字体
                    page.DefaultTextStyle(x => x.FontSize(20));

                    //页眉部分
                    page.Header()
                          .Row(row =>
                          {
                              row.RelativeItem().Column(column =>
                              {
                                  column.Item().AlignCenter().Text("用户信息").FontFamily("simhei").Style(TextStyle.Default.FontSize(22).FontColor(Colors.Blue.Medium));
                                  column.Item().AlignLeft().AlignBottom().Height(50).Width(50).Image(@"C:\iMES\ReourceWeb\logo.png");
                                  column.Item().AlignRight().AlignTop().Text("编号:______________").FontFamily("simhei").Style(TextStyle.Default.FontSize(12));
                              });
                          });
                    //内容部分
                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            //表格
                            x.Item().Table(table =>
                            {
                                //设置表头的列参数占比
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(60);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn(2);
                                });

                                // 表头
                                table.Header(header =>
                                {
                                    header.Cell().AlignCenter().Text("帐号").FontFamily("simhei").Style(TextStyle.Default.FontSize(12));
                                    header.Cell().AlignCenter().Text("性别").FontFamily("simhei").Style(TextStyle.Default.FontSize(12));
                                    header.Cell().AlignCenter().Text("部门").FontFamily("simhei").Style(TextStyle.Default.FontSize(12));
                                    header.Cell().AlignCenter().Text("角色").FontFamily("simhei").Style(TextStyle.Default.FontSize(12));
                                    header.Cell().AlignCenter().Text("真实姓名").FontFamily("simhei").Style(TextStyle.Default.FontSize(12));
                                    header.Cell().AlignCenter().Text("注册时间").FontFamily("simhei").Style(TextStyle.Default.FontSize(12));
                                    header.Cell().ColumnSpan(6).PaddingVertical(4).BorderBottom(1).BorderColor(Colors.Black);
                                });
                                string sql = " select * from Sys_User ";
                                List<Sys_User> list = DBServerProvider.SqlDapper.QueryList<Sys_User>(sql, new { });
                                for (int i = 0; i < list.Count; i++)
                                {
                                    table.Cell().Element(CellStyle).AlignCenter().Text(list[i].UserName).FontFamily("simsun").Style(TextStyle.Default.FontSize(10));
                                    table.Cell().Element(CellStyle).AlignCenter().Text(DictionaryManager.GetDictionaryList("gender", list[i].Gender.ToString())).FontFamily("simsun").Style(TextStyle.Default.FontSize(10));
                                    table.Cell().Element(CellStyle).AlignCenter().Text(list[i].DeptName).FontFamily("simsun").Style(TextStyle.Default.FontSize(10));
                                    table.Cell().Element(CellStyle).AlignCenter().Text(list[i].RoleName).FontFamily("simsun").Style(TextStyle.Default.FontSize(10));
                                    table.Cell().Element(CellStyle).AlignCenter().Text(list[i].UserTrueName).FontFamily("simsun").Style(TextStyle.Default.FontSize(10));
                                    table.Cell().Element(CellStyle).AlignCenter().Text(list[i].CreateDate).FontFamily("simsun").Style(TextStyle.Default.FontSize(10));
                                }
                                static IContainer CellStyle(IContainer container)
                                {
                                    return container.BorderBottom(1).PaddingVertical(4);
                                }

                            });
                        });

                    //页脚部分
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("第").FontFamily("simsun").FontSize(12);
                            x.CurrentPageNumber().FontSize(12);
                            x.Span("页").FontFamily("simsun").FontSize(12);
                        });
                });
            }).GeneratePdf(path_file);
            //返回对应文件
            return fileName;
        }
    }
}
