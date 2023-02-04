/*
 *所有关于Base_ProcessLine类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Base_ProcessLineService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using iMES.Core.Enums;

namespace iMES.Custom.Services
{
    public partial class Base_ProcessLineService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBase_ProcessLineRepository _repository;//访问数据库
        private readonly IBase_NumberRuleRepository _numberRuleRepository;//自定义编码规则访问数据库

        [ActivatorUtilitiesConstructor]
        public Base_ProcessLineService(
            IBase_ProcessLineRepository dbRepository,
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
            AddOnExecuting = (Base_ProcessLine processLine, object list) =>
            {
                if (string.IsNullOrWhiteSpace(processLine.ProcessLineCode))
                    processLine.ProcessLineCode = GetProcessLineCode();
                //如果返回false,后面代码不会再执行、
                if (repository.Exists(x => x.ProcessLineName == processLine.ProcessLineName))
                {
                    return webResponse.Error("工艺路线名称已存在");
                }
                if (repository.Exists(x => x.ProcessLineCode == processLine.ProcessLineCode))
                {
                    return webResponse.Error("工艺路线编号已存在");
                }
                return webResponse.OK();
            };
            return base.Add(saveDataModel);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveDataModel)
        {
            //编辑方法保存数据库前处理
            UpdateOnExecuting = (Base_ProcessLine processLine, object addList, object updateList, List<object> delKeys) =>
            {
                if (repository.Exists(x => x.ProcessLineName == processLine.ProcessLineName && x.ProcessLine_Id != processLine.ProcessLine_Id))
                {
                    return webResponse.Error("工艺路线名称已存在");
                }
                if (repository.Exists(x => x.ProcessLineCode == processLine.ProcessLineCode && x.ProcessLine_Id != processLine.ProcessLine_Id))
                {
                    return webResponse.Error("工艺路线编号已存在");
                }
                List<Base_ProcessLineList> all = new List<Base_ProcessLineList>();
                //新增的明细表
                List<Base_ProcessLineList> add = addList as List<Base_ProcessLineList>;
                //修改的明细表
                List<Base_ProcessLineList> update = updateList as List<Base_ProcessLineList>;
                all.AddRange(add);
                all.AddRange(update);
                for (int i = 0; i < all.Count; i++)
                {
                    if (all[i].ProcessLineType == "process" && all[i].Process_Id == null)
                    {
                        return webResponse.Error("类型选择【工序】，则必输后面【工序】列");
                    }
                    if (all[i].ProcessLineType == "processLine" && all[i].ProcessLineDown_Id == null)
                    {
                        return webResponse.Error("类型选择【工艺路线】，则必输后面【工艺路线】列");
                    }
                    if (all[i].ProcessLineType == "processLine" && processLine.ProcessLine_Id == all[i].ProcessLineDown_Id)
                    {
                        return webResponse.Error("子工艺路线不能添加当前工艺路线");
                    }
                }
                return webResponse.OK();
            };
            return base.Update(saveDataModel);
        }
        /// <summary>
        /// 查询业务代码编写(从表(明细表查询))
        /// </summary>
        /// <param name="pageData"></param>
        /// <returns></returns>
        public override object GetDetailPage(PageDataOptions pageData)
        {
            pageData.Sort = "Sequence";
            pageData.Order = "asc";
            //指定多个字段进行排序
            return base.GetDetailPage(pageData);
        }
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public override WebResponseContent Import(List<IFormFile> files)
        {
            //导入保存前处理(可以对list设置新的值)
            ImportOnExecuting = (List<Base_ProcessLine> list) =>
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(list[i].ProcessLineCode))
                        list[i].ProcessLineCode = GetProcessLineCode();
                    if (repository.Exists(x => x.ProcessLineName == list[i].ProcessLineName))
                    {
                        return webResponse.Error("工艺路线名称已存在");
                    }
                    if (repository.Exists(x => x.ProcessLineCode == list[i].ProcessLineCode))
                    {
                        return webResponse.Error("工艺路线编号已存在");
                    }
                }
                return webResponse.OK();
            };

            //导入后处理(已经写入到数据库了)
            ImportOnExecuted = (List<Base_ProcessLine> list) =>
            {
                return webResponse.OK();
            };
            return base.Import(files);
        }
        /// <summary>
        /// 自动生成工序编号
        /// </summary>
        /// <returns></returns>
        public string GetProcessLineCode()
        {
            DateTime dateNow = (DateTime)DateTime.Now.ToString("yyyy-MM-dd").GetDateTime();
            //查询当天最新的订单号
            string defectItemCode = repository.FindAsIQueryable(x => x.CreateDate > dateNow && x.ProcessLineCode.Length>8)
                .OrderByDescending(x => x.ProcessLineCode)
                .Select(s => s.ProcessLineCode)
                .FirstOrDefault();
            Base_NumberRule numberRule = _numberRuleRepository.FindAsIQueryable(x => x.FormCode == "ProcessLine")
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
