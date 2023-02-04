/*
 *所有关于Base_Process类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Base_ProcessService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using iMES.Custom.IRepositories;
using System;
using System.Collections.Generic;
using iMES.Core.DBManager;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using iMES.Custom.IServices;

namespace iMES.Custom.Services
{
    public partial class Base_ProcessService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBase_ProcessRepository _repository;//访问数据库
        private readonly IBase_NumberRuleRepository _numberRuleRepository;//自定义编码规则访问数据库

        [ActivatorUtilitiesConstructor]
        public Base_ProcessService(
            IBase_ProcessRepository dbRepository,
            IBase_NumberRuleRepository numberRuleRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _numberRuleRepository = numberRuleRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
        WebResponseContent webResponse = new WebResponseContent();
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            //此处saveModel是从前台提交的原生数据，可对数据进修改过滤
            AddOnExecuting = (Base_Process process, object list) =>
            {
                if (string.IsNullOrWhiteSpace(process.ProcessCode))
                    process.ProcessCode = GetProcessCode();
                //如果返回false,后面代码不会再执行、
                if (repository.Exists(x => x.ProcessCode == process.ProcessCode))
                {
                    return webResponse.Error("工序编号已存在");
                }
                if (repository.Exists(x => x.ProcessName == process.ProcessName))
                {
                    return webResponse.Error("工序名称已存在");
                }
                return webResponse.OK();
            };
            //扩展字段开始 start
            AddOnExecuted = (Base_Process process, object list) =>
            {
                return webResponse.OK();
            };
            //扩展字段开始 end
            return base.Add(saveDataModel);
        }
        /// <summary>
        /// 删除工序
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="delList"></param>
        /// <returns></returns>
        public override WebResponseContent Del(object[] keys, bool delList = false)
        {
            base.DelOnExecuted = (object[] processIds) =>
            {
                return new WebResponseContent() { Status = true };
            };
            return base.Del(keys, delList);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveDataModel)
        {
            //编辑方法保存数据库前处理
            UpdateOnExecuting = (Base_Process process, object addList, object updateList, List<object> delKeys) =>
            {
                if (repository.Exists(x => x.ProcessName == process.ProcessName && x.Process_Id != process.Process_Id))
                {
                    return webResponse.Error("不良品项名称已存在");
                }
                if (repository.Exists(x => x.ProcessCode == process.ProcessCode && x.Process_Id != process.Process_Id))
                {
                    return webResponse.Error("不良品项编号已存在");
                }
                return webResponse.OK();
            };
            base.UpdateOnExecuted = (Base_Process process, object obj1, object obj2, List<object> List) =>
            {
                return new WebResponseContent(true);
            };
            return base.Update(saveDataModel);
        }
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public override WebResponseContent Import(List<IFormFile> files)
        {
            //导入保存前处理(可以对list设置新的值)
            ImportOnExecuting = (List<Base_Process> list) =>
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(list[i].ProcessCode))
                        list[i].ProcessCode = GetProcessCode();
                    if (repository.Exists(x => x.ProcessName == list[i].ProcessName))
                    {
                        return webResponse.Error("工序名称已存在");
                    }
                    if (repository.Exists(x => x.ProcessCode == list[i].ProcessCode))
                    {
                        return webResponse.Error("工序编号已存在");
                    }
                }
                return webResponse.OK();
            };

            //导入后处理(已经写入到数据库了)
            ImportOnExecuted = (List<Base_Process> list) =>
            {
                return webResponse.OK();
            };
            return base.Import(files);
        }
        /// <summary>
        /// 自动生成工序编号
        /// </summary>
        /// <returns></returns>
        public string GetProcessCode()
        {
            DateTime dateNow = (DateTime)DateTime.Now.ToString("yyyy-MM-dd").GetDateTime();
            //查询当天最新的订单号
            string defectItemCode = repository.FindAsIQueryable(x => x.CreateDate > dateNow && x.ProcessCode.Length > 8 )
                .OrderByDescending(x => x.ProcessCode)
                .Select(s => s.ProcessCode)
                .FirstOrDefault();
            Base_NumberRule numberRule = _numberRuleRepository.FindAsIQueryable(x => x.FormCode == "Process")
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
        /// <summary>
        /// 工艺路线
        /// </summary>
        /// <returns></returns>
        public object GetProcessListByLineID(int ProcessLine_Id)
        {
            string sql = @" select b.* from  Func_GetProcessLineByID("+ ProcessLine_Id +@") a
	                                    left join Base_Process b on a.Process_Id = b.Process_Id
	                                    order by a.Sequence asc ";
            List<Base_Process> list = DBServerProvider.SqlDapper.QueryList<Base_Process>(sql, null);
            return list;
        }
    }
}
