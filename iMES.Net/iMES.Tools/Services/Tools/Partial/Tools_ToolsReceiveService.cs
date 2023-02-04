/*
 *所有关于Tools_ToolsReceive类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Tools_ToolsReceiveService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using iMES.Tools.IRepositories;
using iMES.Custom.IRepositories;
using System;
using System.Collections.Generic;

namespace iMES.Tools.Services
{
    public partial class Tools_ToolsReceiveService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITools_ToolsReceiveRepository _repository;//访问数据库
        private readonly IBase_NumberRuleRepository _numberRuleRepository;//自定义编码规则访问数据库
        private readonly ITools_ToolRepository _toolRepository;//自定义编码规则访问数据库

        [ActivatorUtilitiesConstructor]
        public Tools_ToolsReceiveService(
            ITools_ToolsReceiveRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            IBase_NumberRuleRepository numberRuleRepository,
             ITools_ToolRepository toolRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _numberRuleRepository = numberRuleRepository;
            _toolRepository = toolRepository;
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
            AddOnExecuting = (Tools_ToolsReceive receive, object list) =>
            {
                if (string.IsNullOrWhiteSpace(receive.ToolsReceiveCode))
                    receive.ToolsReceiveCode = GetToolsReceiveCode();
                //如果返回false,后面代码不会再执行
                if (repository.Exists(x => x.ToolsReceiveCode == receive.ToolsReceiveCode))
                {
                    return webResponse.Error("工具领用编码已存在");
                }
                List<Tools_ToolsReceiveList> toolList = list as List<Tools_ToolsReceiveList>;
                List<Tools_ToolsReceiveList> checkList = toolList.Where(x => x.Qty == 0).ToList();
                if (checkList.Count>0)
                {
                    return webResponse.Error("数量不能为空或者0！");
                }
                for (int i = 0; i < toolList.Count; i++)
                {
                    var tool = _toolRepository.FindAsIQueryable(x => x.ToolId == toolList[i].ToolId)
                               .OrderByDescending(x => x.CreateDate)
                               .FirstOrDefault();
                    tool.QuantityAvail = tool.QuantityAvail - toolList[i].Qty;
                    _toolRepository.Update(tool,true);
                }  
                return webResponse.OK();
            };
            return base.Add(saveDataModel);
        }
        /// <summary>
        /// 自动生成设备编号
        /// </summary>
        /// <returns></returns>
        public string GetToolsReceiveCode()
        {
            DateTime dateNow = (DateTime)DateTime.Now.ToString("yyyy-MM-dd").GetDateTime();
            //查询当天最新的订单号
            string defectItemCode = repository.FindAsIQueryable(x => x.CreateDate > dateNow && x.ToolsReceiveCode.Length>8)
                .OrderByDescending(x => x.ToolsReceiveCode)
                .Select(s => s.ToolsReceiveCode)
                .FirstOrDefault();
            Base_NumberRule numberRule = _numberRuleRepository.FindAsIQueryable(x => x.FormCode == "ToolsReceive")
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
}
