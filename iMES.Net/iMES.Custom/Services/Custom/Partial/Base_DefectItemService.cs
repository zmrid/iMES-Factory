/*
 *所有关于Base_DefectItem类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Base_DefectItemService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using iMES.Custom.IServices;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace iMES.Custom.Services
{
    public partial class Base_DefectItemService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBase_DefectItemRepository _repository;//访问数据库
        private readonly IBase_NumberRuleRepository _numberRuleRepository;//自定义编码规则访问数据库

        [ActivatorUtilitiesConstructor]
        public Base_DefectItemService(
            IBase_DefectItemRepository dbRepository,
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
            AddOnExecuting = (Base_DefectItem defectItem, object list) =>
            {
                if (string.IsNullOrWhiteSpace(defectItem.DefectItemCode))
                    defectItem.DefectItemCode = GetDefectItemCode();
                //如果返回false,后面代码不会再执行、
                if (repository.Exists(x => x.DefectItemName == defectItem.DefectItemName))
                {
                    return webResponse.Error("不良品项名称已存在");
                }
                if (repository.Exists(x => x.DefectItemCode == defectItem.DefectItemCode))
                {
                    return webResponse.Error("不良品项编号已存在");
                }
                return webResponse.OK();
            };
            //扩展字段开始 start
            AddOnExecuted = (Base_DefectItem defectItem, object list) =>
            {
                return webResponse.OK();
            };
            //扩展字段开始 end
            return base.Add(saveDataModel);
        }
        /// <summary>
        /// 删除不良品项
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="delList"></param>
        /// <returns></returns>
        public override WebResponseContent Del(object[] keys, bool delList = false)
        {
            base.DelOnExecuted = (object[] defectItemIds) =>
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
            UpdateOnExecuting = (Base_DefectItem defectItem, object addList, object updateList, List<object> delKeys) =>
            {
                if (repository.Exists(x => x.DefectItemName == defectItem.DefectItemName && x.DefectItem_Id != defectItem.DefectItem_Id))
                {
                    return webResponse.Error("不良品项名称已存在");
                }
                if (repository.Exists(x => x.DefectItemCode == defectItem.DefectItemCode && x.DefectItem_Id != defectItem.DefectItem_Id))
                {
                    return webResponse.Error("不良品项编号已存在");
                }
                return webResponse.OK();
            };
            base.UpdateOnExecuted = (Base_DefectItem defectItem, object obj1, object obj2, List<object> List) =>
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
            ImportOnExecuting = (List<Base_DefectItem> list) =>
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(list[i].DefectItemCode))
                        list[i].DefectItemCode = GetDefectItemCode();
                    if (repository.Exists(x => x.DefectItemName == list[i].DefectItemName))
                    {
                        return webResponse.Error("不良品项名称已存在");
                    }
                    if (repository.Exists(x => x.DefectItemCode == list[i].DefectItemCode))
                    {
                        return webResponse.Error("不良品项编号已存在");
                    }
                }
                return webResponse.OK();
            };

            //导入后处理(已经写入到数据库了)
            ImportOnExecuted = (List<Base_DefectItem> list) =>
            {
                return webResponse.OK();
            };
            return base.Import(files);
        }
        /// <summary>
        /// 自动生成不良品编号
        /// </summary>
        /// <returns></returns>
        public string GetDefectItemCode()
        {
            DateTime dateNow = (DateTime)DateTime.Now.ToString("yyyy-MM-dd").GetDateTime();
            //查询当天最新的订单号
            string defectItemCode = repository.FindAsIQueryable(x => x.CreateDate > dateNow && x.DefectItemCode.Length>8)
                .OrderByDescending(x => x.DefectItemCode)
                .Select(s => s.DefectItemCode)
                .FirstOrDefault();
            Base_NumberRule numberRule =  _numberRuleRepository.FindAsIQueryable(x => x.FormCode == "DefectItem")
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
