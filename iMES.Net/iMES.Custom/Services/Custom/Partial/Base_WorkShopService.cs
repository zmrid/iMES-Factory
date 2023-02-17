/*
 *所有关于Base_WorkShop类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Base_WorkShopService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using System.Collections.Generic;
using System;

namespace iMES.Custom.Services
{
    public partial class Base_WorkShopService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBase_WorkShopRepository _repository;//访问数据库
        private readonly IBase_NumberRuleRepository _numberRuleRepository;//自定义编码规则访问数据库

        [ActivatorUtilitiesConstructor]
        public Base_WorkShopService(
            IBase_WorkShopRepository dbRepository,
            IBase_NumberRuleRepository numberRuleRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _numberRuleRepository = numberRuleRepository;
            _repository = dbRepository;
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
            AddOnExecuting = (Base_WorkShop workShop, object list) =>
            {
                if (string.IsNullOrWhiteSpace(workShop.WorkShopCode))
                    workShop.WorkShopCode = GetWorkShopCode();
                //如果返回false,后面代码不会再执行
                if (repository.Exists(x => x.WorkShopCode == workShop.WorkShopCode))
                {
                    return webResponse.Error("车间编号已存在");
                }
                return webResponse.OK();
            };
            return base.Add(saveDataModel);
        }
        /// <summary>
        /// 编辑操作
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveModel)
        {
            UpdateOnExecute = (SaveModel model) =>
            {
                return webResponse.OK();
            };
            //编辑方法保存数据库前处理
            UpdateOnExecuting = (Base_WorkShop workShop, object addList, object updateList, List<object> delKeys) =>
            {
                //如果返回false,后面代码不会再执行
                if (repository.Exists(x => x.WorkShopCode == workShop.WorkShopCode && x.WorkShopId != workShop.WorkShopId))
                {
                    return webResponse.Error("车间编号已存在");
                }
                return webResponse.OK();
            };
            return base.Update(saveModel);
        }
        /// <summary>
        /// 自动生成设备编号
        /// </summary>
        /// <returns></returns>
        public string GetWorkShopCode()
        {
            DateTime dateNow = (DateTime)DateTime.Now.ToString("yyyy-MM-dd").GetDateTime();
            //查询当天最新的订单号
            string defectItemCode = repository.FindAsIQueryable(x => x.CreateDate > dateNow && x.WorkShopCode.Length>8)
                .OrderByDescending(x => x.WorkShopCode)
                .Select(s => s.WorkShopCode)
                .FirstOrDefault();
            Base_NumberRule numberRule = _numberRuleRepository.FindAsIQueryable(x => x.FormCode == "WorkShop")
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
