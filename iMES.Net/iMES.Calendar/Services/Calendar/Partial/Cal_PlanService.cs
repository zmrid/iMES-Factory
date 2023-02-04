/*
 *所有关于Cal_Plan类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Cal_PlanService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;
using System.Linq;
using iMES.Core.Utilities;
using System.Linq.Expressions;
using iMES.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Calendar.IRepositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using iMES.Calendar.Repositories;
using iMES.Core.Enums;
using iMES.Custom.IRepositories;

namespace iMES.Calendar.Services
{
    public partial class Cal_PlanService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICal_PlanRepository _repository;//访问数据库
        private readonly ICal_PlanShiftRepository _shiftRepository;//访问数据库
        private readonly ICal_PlanTeamRepository _teamRepository;//访问数据库
        private readonly IBase_NumberRuleRepository _numberRuleRepository;//自定义编码规则访问数据库

        [ActivatorUtilitiesConstructor]
        public Cal_PlanService(
            ICal_PlanRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            ICal_PlanShiftRepository shiftRepository,
            ICal_PlanTeamRepository teamRepository,
            IBase_NumberRuleRepository numberRuleRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _shiftRepository = shiftRepository;
            _teamRepository = teamRepository;
            _numberRuleRepository = numberRuleRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
        /// <summary>
        /// 获取table1的数据
        /// </summary>
        /// <param name="loadData"></param>
        /// <returns></returns>
        public async Task<object> GetTable1Data(PageDataOptions loadData)
        {
            //Equip_SpotMaintPlanModelBody.vue中loadTableBefore方法查询前给loadData.Value写入的值
            List<where> list = loadData.Wheres.DeserializeObject<List<where>>();
            //获取查询到的总和数
            int total = await Cal_PlanShiftRepository.Instance.FindAsIQueryable(x => x.PlanId == new Guid(list[0].value)).CountAsync();

            var data = await Cal_PlanShiftRepository.Instance
                //这里可以自己查询条件，从 loadData.Value找前台自定义传的查询条件
                .FindAsIQueryable(x => x.PlanId == new Guid(list[0].value))
                //分页
                .TakeOrderByPage(1, 10, x => new Dictionary<object, QueryOrderBy>() { { x.CreateDate, QueryOrderBy.Desc } })
                .Select(s => new { s.PlanShiftId, s.PlanId, s.PlanShiftName,s.Sequence,s.StartTime,s.EndTime, s.CreateID, s.Creator, s.CreateDate, s.ModifyID, s.Modifier, s.ModifyDate })
                .ToListAsync();
            object gridData = new { rows = data, total };
            return gridData;
        }

        /// <summary>
        /// 获取table2的数据
        /// </summary>
        /// <param name="loadData"></param>
        /// <returns></returns>
        public async Task<object> GetTable2Data(PageDataOptions loadData)
        {
            //Equip_SpotMaintPlanModelBody.vue中loadTableBefore方法查询前给loadData.Value写入的值
            //获取查询到的总和数
            List<where> list = loadData.Wheres.DeserializeObject<List<where>>();
            //获取查询到的总和数
            int total = await repository.DbContext.Set<Cal_PlanTeam>().Where(x => x.PlanId == new Guid(list[0].value)).CountAsync();
            //从 loadData.Value取查询条件，分页等信息
            //这里可以自己查询条件，从 loadData.Value找前台自定义传的查询条件
            var data = await repository.DbContext.Set<Cal_PlanTeam>().Where(x => x.PlanId == new Guid(list[0].value))
                //分页
                .TakeOrderByPage(1, 10, x => new Dictionary<object, QueryOrderBy>() { { x.CreateDate, QueryOrderBy.Desc } })
                .Select(s => new {   s.PlanTeamId
                                              ,s.PlanId
                                              ,s.TeamId
                                              ,s.TeamCode
                                              ,s.TeamName
                                              ,s.Sequence, s.CreateID, s.Creator, s.CreateDate, s.ModifyID, s.Modifier, s.ModifyDate })
                .ToListAsync();
            object gridData = new { rows = data, total };
            return gridData;
        }
        WebResponseContent _webResponse = new WebResponseContent();
        /// <summary>
        /// 自定义保存从表数据逻辑
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            //取出校验完成后的从表1.2的数据
            TableExtra tableExtra = saveDataModel.Extra.ToString().DeserializeObject<TableExtra>();
            //保存到数据库前
            AddOnExecuting = (Cal_Plan plan, object obj) =>
            {
                if (string.IsNullOrWhiteSpace(plan.PlanCode))
                    plan.PlanCode = GetPlanCode();
                //如果返回false,后面代码不会再执行
                if (repository.Exists(x => x.PlanCode == plan.PlanCode))
                {
                    return _webResponse.Error("计划编号已存在");
                }
                return WebResponseContent.Instance.OK();
            };
            //Equip_SpotMaintPlan 此处已经提交了数据库，处于事务中
            AddOnExecuted = (Cal_Plan plan, object obj) =>
            {
                int i = 0;
                //在此操作tableExtra从表信息
                List<Cal_PlanShift> newsList = tableExtra.Table1List.Select(s => new Cal_PlanShift
                {
                    PlanShiftId = s.PlanShiftId,
                    PlanId = plan.PlanId,
                    PlanShiftName = s.PlanShiftName,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    Sequence = i++
                }).ToList();

                //id=0的默认为新增的数据
                List<Cal_PlanShift> addList = newsList.Where(x => x.PlanShiftId == new Guid("00000000-0000-0000-0000-000000000000")).ToList();
                //设置默认创建人信息
                addList.ForEach(x => { x.SetCreateDefaultVal(); });
                //新增
                repository.AddRange(addList);
                int j = 0;
                //点检保养项目
                List<Cal_PlanTeam> newsList2 = tableExtra.Table2List.Select(s => new Cal_PlanTeam
                {
                    PlanTeamId = s.PlanTeamId,
                    PlanId = plan.PlanId,
                    TeamId = s.TeamId,
                    TeamCode = s.TeamCode,
                    TeamName = s.TeamName,
                    Sequence = j++
                }).ToList();

                //id=0的默认为新增的数据
                List<Cal_PlanTeam> addList2 = newsList2.Where(x => x.PlanTeamId == new Guid("00000000-0000-0000-0000-000000000000")).ToList();
                //设置默认创建人信息
                addList2.ForEach(x => { x.SetCreateDefaultVal(); });
                //新增
                repository.AddRange(addList2);
                //最终保存
                repository.SaveChanges();
                //生成班组排班
                if (plan.Status == 2)
                {
                    var teamShift = new List<Cal_TeamShift>();
                    for (var date = Convert.ToDateTime(plan.StartDate); date <= Convert.ToDateTime(plan.EndDate); date = date.AddDays(2))
                    {
                        if (newsList.Count >= 1)
                        {
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[0].TeamId.ToString(),
                                TeamName = newsList2[0].TeamName,
                                ShiftId = newsList[0].PlanShiftId,
                                ShiftName = newsList[0].PlanShiftName,
                                Sequence = newsList[0].Sequence,
                                PlanId = plan.PlanId
                            });
                        }
                        if (newsList.Count >= 2)
                        {
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[1].TeamId.ToString(),
                                TeamName = newsList2[1].TeamName,
                                ShiftId = newsList[1].PlanShiftId,
                                ShiftName = newsList[1].PlanShiftName,
                                Sequence = newsList[1].Sequence,
                                PlanId = plan.PlanId
                            });
                        }
                        if (newsList.Count >= 3)
                        {
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[2].TeamId.ToString(),
                                TeamName = newsList2[2].TeamName,
                                ShiftId = newsList[2].PlanShiftId,
                                ShiftName = newsList[2].PlanShiftName,
                                Sequence = newsList[2].Sequence,
                                PlanId = plan.PlanId
                            });
                        }
                    };
                    for (var date = Convert.ToDateTime(plan.StartDate).AddDays(1); date <= Convert.ToDateTime(plan.EndDate); date = date.AddDays(2))
                    {
                        if (newsList.Count == 1 && newsList2.Count == 1)
                        {
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[0].TeamId.ToString(),
                                TeamName = newsList2[0].TeamName,
                                ShiftId = newsList[0].PlanShiftId,
                                ShiftName = newsList[0].PlanShiftName,
                                Sequence = newsList[0].Sequence,
                                PlanId = plan.PlanId
                            });
                        }
                        if (newsList.Count == 2 && newsList2.Count == 2)
                        {
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[0].TeamId.ToString(),
                                TeamName = newsList2[0].TeamName,
                                ShiftId = newsList[1].PlanShiftId,
                                ShiftName = newsList[1].PlanShiftName,
                                Sequence = newsList[1].Sequence,
                                PlanId = plan.PlanId
                            });
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[1].TeamId.ToString(),
                                TeamName = newsList2[1].TeamName,
                                ShiftId = newsList[0].PlanShiftId,
                                ShiftName = newsList[0].PlanShiftName,
                                Sequence = newsList[0].Sequence,
                                PlanId = plan.PlanId
                            });
                        }
                        if (newsList.Count == 3 && newsList2.Count == 3)
                        {
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[2].TeamId.ToString(),
                                TeamName = newsList2[2].TeamName,
                                ShiftId = newsList[0].PlanShiftId,
                                ShiftName = newsList[0].PlanShiftName,
                                Sequence = newsList[0].Sequence,
                                PlanId = plan.PlanId
                            });
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[1].TeamId.ToString(),
                                TeamName = newsList2[1].TeamName,
                                ShiftId = newsList[1].PlanShiftId,
                                ShiftName = newsList[1].PlanShiftName,
                                Sequence = newsList[1].Sequence,
                                PlanId = plan.PlanId
                            });
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[0].TeamId.ToString(),
                                TeamName = newsList2[0].TeamName,
                                ShiftId = newsList[2].PlanShiftId,
                                ShiftName = newsList[2].PlanShiftName,
                                Sequence = newsList[2].Sequence,
                                PlanId = plan.PlanId
                            });
                        }
                    };
                    //新增
                    repository.AddRange(teamShift);
                    //最终保存
                    repository.SaveChanges();
                }
                return WebResponseContent.Instance.OK();
            };
            return base.Add(saveDataModel);
        }

        /// <summary>
        /// 自定义更新从表操作
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveModel)
        {
            //取出校验完成后的从表1.2的数据
            TableExtra tableExtra = saveModel.Extra.ToString().DeserializeObject<TableExtra>();

            //保存到数据库前
            UpdateOnExecuting = (Cal_Plan plan, object obj, object obj2, List<object> list) =>
            {
                return WebResponseContent.Instance.OK();
            };

            //App_ReportPrice 此处已经提交了数据库，处于事务中
            UpdateOnExecuted = (Cal_Plan plan, object obj, object obj2, List<object> list) =>
            {
                //在此操作tableExtra从表信息
                List<Cal_PlanShift> newsList = tableExtra.Table1List.Select(s => new Cal_PlanShift
                {
                    PlanShiftId = s.PlanShiftId,
                    PlanId = plan.PlanId,
                    PlanShiftName = s.PlanShiftName,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime
                }).ToList();

                //id=0的默认为新增的数据
                List<Cal_PlanShift> addList = newsList.Where(x => x.PlanShiftId == new Guid("00000000-0000-0000-0000-000000000000")).ToList();
                //设置默认创建人信息
                addList.ForEach(x => { x.SetCreateDefaultVal(); });

                //获取所有编辑行
                List<Guid> editIds = newsList.Where(x => x.PlanShiftId != new Guid("00000000-0000-0000-0000-000000000000")).Select(s => s.PlanShiftId).ToList();
                addList.ForEach(x => { x.SetModifyDefaultVal(); });
                //从数据库查询编辑的行是否存在，如果数据库不存在，执行修改操作会异常
                List<Guid> existsIds = Cal_PlanShiftRepository.Instance.FindAsIQueryable(x => editIds.Contains(x.PlanShiftId)).Select(s => s.PlanShiftId).ToList();

                //获取实际可以修改的数据
                List<Cal_PlanShift> updateList = newsList.Where(x => existsIds.Contains(x.PlanShiftId)).ToList();

                //设置默认修改人信息
                updateList.ForEach(x => { x.SetModifyDefaultVal(); });
                //新增
                repository.AddRange(addList);
                //修改(第二个参数指定要修改的字段,第三个参数执行保存)
                repository.UpdateRange(updateList, x => new { x.PlanShiftName, x.StartTime, x.EndTime, x.Modifier, x.ModifyDate, x.ModifyID });
                //点检保养项目
                List<Cal_PlanTeam> newsList2 = tableExtra.Table2List.Select(s => new Cal_PlanTeam
                {
                    PlanTeamId = s.PlanTeamId,
                    PlanId = plan.PlanId,
                    TeamId = s.TeamId,
                    TeamCode = s.TeamCode,
                    TeamName = s.TeamName,
                }).ToList();

                //id=0的默认为新增的数据
                List<Cal_PlanTeam> addList2 = newsList2.Where(x => x.PlanTeamId == new Guid("00000000-0000-0000-0000-000000000000")).ToList();
                //设置默认创建人信息
                addList2.ForEach(x => { x.SetCreateDefaultVal(); });

                //获取所有编辑行
                List<Guid> editIds2 = newsList2.Where(x => x.PlanTeamId != new Guid("00000000-0000-0000-0000-000000000000")).Select(s => s.PlanTeamId).ToList();
                addList2.ForEach(x => { x.SetModifyDefaultVal(); });
                //从数据库查询编辑的行是否存在，如果数据库不存在，执行修改操作会异常
                List<Guid> existsIds2 = Cal_PlanTeamRepository.Instance.FindAsIQueryable(x => editIds.Contains(x.PlanTeamId)).Select(s => s.PlanTeamId).ToList();

                //获取实际可以修改的数据
                List<Cal_PlanTeam> updateList2 = newsList2.Where(x => existsIds2.Contains(x.PlanTeamId)).ToList();

                //设置默认修改人信息
                updateList2.ForEach(x => { x.SetModifyDefaultVal(); });
                //新增
                repository.AddRange(addList2);
                //修改(第二个参数指定要修改的字段,第三个参数执行保存)
                repository.UpdateRange(updateList2, x => new { x.TeamId, x.TeamCode, x.TeamName, x.Modifier, x.ModifyDate, x.ModifyID });
                //最终保存
                repository.SaveChanges();
                //生成班组排班
                if (plan.Status == 2)
                {
                    var teamShift = new List<Cal_TeamShift>();
                    for (var date = Convert.ToDateTime(plan.StartDate); date <= Convert.ToDateTime(plan.EndDate); date = date.AddDays(2))
                    {
                        if (newsList.Count >= 1)
                        {
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[0].TeamId.ToString(),
                                TeamName = newsList2[0].TeamName,
                                ShiftId = newsList[0].PlanShiftId,
                                ShiftName = newsList[0].PlanShiftName,
                                Sequence = newsList[0].Sequence,
                                PlanId = plan.PlanId
                            });
                        }
                        if (newsList.Count >= 2)
                        {
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[1].TeamId.ToString(),
                                TeamName = newsList2[1].TeamName,
                                ShiftId = newsList[1].PlanShiftId,
                                ShiftName = newsList[1].PlanShiftName,
                                Sequence = newsList[1].Sequence,
                                PlanId = plan.PlanId
                            });
                        }
                        if (newsList.Count >= 3)
                        {
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[2].TeamId.ToString(),
                                TeamName = newsList2[2].TeamName,
                                ShiftId = newsList[2].PlanShiftId,
                                ShiftName = newsList[2].PlanShiftName,
                                Sequence = newsList[2].Sequence,
                                PlanId = plan.PlanId
                            });
                        }
                    };
                    for (var date = Convert.ToDateTime(plan.StartDate).AddDays(1); date <= Convert.ToDateTime(plan.EndDate); date = date.AddDays(2))
                    {
                        if (newsList.Count == 1 && newsList2.Count == 1)
                        {
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[0].TeamId.ToString(),
                                TeamName = newsList2[0].TeamName,
                                ShiftId = newsList[0].PlanShiftId,
                                ShiftName = newsList[0].PlanShiftName,
                                Sequence = newsList[0].Sequence,
                                PlanId = plan.PlanId
                            });
                        }
                        if (newsList.Count == 2 && newsList2.Count == 2)
                        {
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[0].TeamId.ToString(),
                                TeamName = newsList2[0].TeamName,
                                ShiftId = newsList[1].PlanShiftId,
                                ShiftName = newsList[1].PlanShiftName,
                                Sequence = newsList[1].Sequence,
                                PlanId = plan.PlanId
                            });
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[1].TeamId.ToString(),
                                TeamName = newsList2[1].TeamName,
                                ShiftId = newsList[0].PlanShiftId,
                                ShiftName = newsList[0].PlanShiftName,
                                Sequence = newsList[0].Sequence,
                                PlanId = plan.PlanId
                            });
                        }
                        if (newsList.Count == 3 && newsList2.Count == 3)
                        {
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[2].TeamId.ToString(),
                                TeamName = newsList2[2].TeamName,
                                ShiftId = newsList[0].PlanShiftId,
                                ShiftName = newsList[0].PlanShiftName,
                                Sequence = newsList[0].Sequence,
                                PlanId = plan.PlanId
                            });
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[1].TeamId.ToString(),
                                TeamName = newsList2[1].TeamName,
                                ShiftId = newsList[1].PlanShiftId,
                                ShiftName = newsList[1].PlanShiftName,
                                Sequence = newsList[1].Sequence,
                                PlanId = plan.PlanId
                            });
                            teamShift.Add(new Cal_TeamShift
                            {
                                TeamShiftId = new Guid(),
                                TheDate = date,
                                TeamId = newsList2[0].TeamId.ToString(),
                                TeamName = newsList2[0].TeamName,
                                ShiftId = newsList[2].PlanShiftId,
                                ShiftName = newsList[2].PlanShiftName,
                                Sequence = newsList[2].Sequence,
                                PlanId = plan.PlanId
                            });
                        }
                    };
                    //新增
                    repository.AddRange(teamShift);
                    //最终保存
                    repository.SaveChanges();
                }
                return WebResponseContent.Instance.OK();
            };
            return base.Update(saveModel);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="delList"></param>
        /// <returns></returns>
        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                List<object> idsDevice = Cal_PlanShiftRepository.Instance.FindAsIQueryable(x => x.PlanId == new Guid(keys[i].ToString())).Select(s => (object)s.PlanShiftId).ToList();
                List<object> idsProject = Cal_PlanTeamRepository.Instance.FindAsIQueryable(x => x.PlanId == new Guid(keys[i].ToString())).Select(s => (object)s.PlanTeamId).ToList();
                object[] arrayDevice = idsDevice.ToArray();
                object[] arrayProject = idsProject.ToArray();
                _shiftRepository.DeleteWithKeys(arrayDevice, true);
                _teamRepository.DeleteWithKeys(arrayProject, true);
            }
            //最终保存
            repository.SaveChanges();
            return base.Del(keys, true);
        }
        /// <summary>
        /// 自动生成设备编号
        /// </summary>
        /// <returns></returns>
        public string GetPlanCode()
        {
            DateTime dateNow = (DateTime)DateTime.Now.ToString("yyyy-MM-dd").GetDateTime();
            //查询当天最新的订单号
            string defectItemCode = repository.FindAsIQueryable(x => x.CreateDate > dateNow && x.PlanCode.Length > 8)
                .OrderByDescending(x => x.PlanCode)
                .Select(s => s.PlanCode)
                .FirstOrDefault();
            Base_NumberRule numberRule = _numberRuleRepository.FindAsIQueryable(x => x.FormCode == "CalPlan")
                .OrderByDescending(x => x.CreateDate)
                .FirstOrDefault();
            if (numberRule != null)
            {
                string rule = numberRule.Prefix + DateTime.Now.ToString(numberRule.SubmitTime.Replace("hh", "HH"));
                if (string.IsNullOrEmpty(defectItemCode))
                {
                    rule += "1".PadLeft(numberRule.SerialNumber, '0');
                }
                else
                {
                    rule += (defectItemCode.Substring(defectItemCode.Length - numberRule.SerialNumber).GetInt() + 1).ToString("0".PadLeft(numberRule.SerialNumber, '0'));
                }
                return rule;
            }
            else //如果自定义序号配置项不存在，则使用日期生成
            {
                return DateTime.Now.ToString("yyyyMMddHHmmssffff");
            }
        }
    }
    public class Table1
    {
        /// <summary>
        ///计划班次主键
        /// </summary>
        [Key]
        [Display(Name = "计划班次主键")]
        [Column(TypeName = "uniqueidentifier")]
        [Editable(true)]
        public Guid PlanShiftId { get; set; }

        /// <summary>
        ///计划主键
        /// </summary>
        [Display(Name = "计划主键")]
        [Column(TypeName = "uniqueidentifier")]
        [Editable(true)]
        public Guid PlanId { get; set; }

        /// <summary>
        ///显示顺序
        /// </summary>
        [Display(Name = "显示顺序")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? Sequence { get; set; }

        /// <summary>
        ///班次名称
        /// </summary>
        [Display(Name = "班次名称")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string PlanShiftName { get; set; }

        /// <summary>
        ///开始时间
        /// </summary>
        [Display(Name = "开始时间")]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        [Editable(true)]
        public string StartTime { get; set; }

        /// <summary>
        ///结束时间
        /// </summary>
        [Display(Name = "结束时间")]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        [Editable(true)]
        public string EndTime { get; set; }

        /// <summary>
        ///创建人编号
        /// </summary>
        [Display(Name = "创建人编号")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? CreateID { get; set; }

        /// <summary>
        ///创建人
        /// </summary>
        [Display(Name = "创建人")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Editable(true)]
        public string Creator { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///修改人编号
        /// </summary>
        [Display(Name = "修改人编号")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? ModifyID { get; set; }

        /// <summary>
        ///修改人
        /// </summary>
        [Display(Name = "修改人")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Editable(true)]
        public string Modifier { get; set; }

        /// <summary>
        ///修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? ModifyDate { get; set; }
    }
    public class Table2
    {
        /// <summary>
        ///计划班组主键
        /// </summary>
        [Key]
        [Display(Name = "计划班组主键")]
        [Column(TypeName = "uniqueidentifier")]
        [Editable(true)]
        public Guid PlanTeamId { get; set; }

        /// <summary>
        ///计划主键
        /// </summary>
        [Display(Name = "计划主键")]
        [Column(TypeName = "uniqueidentifier")]
        [Editable(true)]
        public Guid PlanId { get; set; }

        /// <summary>
        ///班组主键
        /// </summary>
        [Display(Name = "班组主键")]
        [Column(TypeName = "uniqueidentifier")]
        [Editable(true)]
        public Guid TeamId { get; set; }

        /// <summary>
        ///班组编码
        /// </summary>
        [Display(Name = "班组编码")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string TeamCode { get; set; }

        /// <summary>
        ///班组名称
        /// </summary>
        [Display(Name = "班组名称")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Editable(true)]
        public string TeamName { get; set; }

        /// <summary>
        ///显示顺序
        /// </summary>
        [Display(Name = "显示顺序")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? Sequence { get; set; }

        /// <summary>
        ///创建人编号
        /// </summary>
        [Display(Name = "创建人编号")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? CreateID { get; set; }

        /// <summary>
        ///创建人
        /// </summary>
        [Display(Name = "创建人")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Editable(true)]
        public string Creator { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///修改人编号
        /// </summary>
        [Display(Name = "修改人编号")]
        [Column(TypeName = "int")]
        [Editable(true)]
        public int? ModifyID { get; set; }

        /// <summary>
        ///修改人
        /// </summary>
        [Display(Name = "修改人")]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Editable(true)]
        public string Modifier { get; set; }

        /// <summary>
        ///修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        [Column(TypeName = "datetime")]
        [Editable(true)]
        public DateTime? ModifyDate { get; set; }
    }
    public class TableExtra
    {
        /// <summary>
        /// 从表1
        /// </summary>
        public List<Table1> Table1List { get; set; }

        /// <summary>
        /// 从表2
        /// </summary>
        public List<Table2> Table2List { get; set; }
    }
    public class where
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
