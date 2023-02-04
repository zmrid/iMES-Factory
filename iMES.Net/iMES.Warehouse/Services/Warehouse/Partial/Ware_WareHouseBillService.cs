/*
 *所有关于Ware_WareHouseBill类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Ware_WareHouseBillService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using iMES.Warehouse.IRepositories;
using System;
using iMES.Custom.IRepositories;
using System.Collections.Generic;
using iMES.Warehouse.Repositories;
using iMES.Core.Enums;
using iMES.Custom.Services;

namespace iMES.Warehouse.Services
{
    public partial class Ware_WareHouseBillService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWare_WareHouseBillRepository _repository;//访问数据库
        private readonly IBase_NumberRuleRepository _numberRuleRepository;//自定义编码规则访问数据库
        private readonly IBase_ProductRepository _productRepository;//自定义编码规则访问数据库

        [ActivatorUtilitiesConstructor]
        public Ware_WareHouseBillService(
            IWare_WareHouseBillRepository dbRepository,
            IBase_NumberRuleRepository numberRuleRepository,
            IBase_ProductRepository productRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _numberRuleRepository = numberRuleRepository;
            _productRepository = productRepository;
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
            AddOnExecuting = (Ware_WareHouseBill wareHouseBill, object list) =>
            {
                if (string.IsNullOrWhiteSpace(wareHouseBill.WareHouseBillCode))
                    wareHouseBill.WareHouseBillCode = GetWareHouseBillCode();
                //如果返回false,后面代码不会再执行
                if (repository.Exists(x => x.WareHouseBillCode == wareHouseBill.WareHouseBillCode))
                {
                    return webResponse.Error("入库单编号已存在");
                }
                return webResponse.OK();
            };
            // 在保存数据库后的操作，此时已进行数据提交，但未提交事务，如果返回false，则会回滚提交
    /*        AddOnExecuted = (Ware_WareHouseBill wareHouseBill, object list) =>
            {
                List<Ware_WareHouseBillList> productList = list as List<Ware_WareHouseBillList>;
                for (int i = 0; i < productList.Count; i++)
                {
                    Base_Product product = _productRepository.FindAsIQueryable(x => x.Product_Id == productList[i].Product_Id).FirstOrDefault();
                    product.InventoryQty = (product.InventoryQty == null ? 0 : product.InventoryQty) + productList[i].InStoreQty.GetInt();
                    _productRepository.Update(product, true);
                }
                return webResponse.OK();
            };*/
            return base.Add(saveDataModel);
        }
        public override object GetDetailPage(PageDataOptions pageData)
        {
            var query = Ware_WareHouseBillListRepository.Instance.IQueryablePage<Ware_WareHouseBillList>(
                 pageData.Page,
                 pageData.Rows,
                 out int count,
                 x => x.WareHouseBill_Id == pageData.Value.GetInt(),
                  orderBy: x => new Dictionary<object, QueryOrderBy>() { { x.CreateDate, QueryOrderBy.Desc } }
                );
            PageGridData<Ware_WareHouseBillList> detailGrid = new PageGridData<Ware_WareHouseBillList>();
            detailGrid.rows = query.ToList();
            detailGrid.total = count;
            //获取当前库存数量
            List<Base_Product> storeList = Base_ProductService.GetStoreNumber();
            for (int i = 0; i < detailGrid.rows.Count; i++)
            {
                if (storeList.Exists(x => x.Product_Id == detailGrid.rows[i].Product_Id))
                {
                    detailGrid.rows[i].InventoryQty = storeList.Find(x => x.Product_Id == detailGrid.rows[i].Product_Id).InventoryQty;
                }
                else
                {
                    detailGrid.rows[i].InventoryQty = 0;
                }
            }
            return detailGrid;
        }
        /// <summary>
        /// 自动生成工序编号
        /// </summary>
        /// <returns></returns>
        public string GetWareHouseBillCode()
        {
            DateTime dateNow = (DateTime)DateTime.Now.ToString("yyyy-MM-dd").GetDateTime();
            //查询当天最新的订单号
            string defectItemCode = repository.FindAsIQueryable(x => x.CreateDate > dateNow && x.WareHouseBillCode.Length>8)
                .OrderByDescending(x => x.WareHouseBillCode)
                .Select(s => s.WareHouseBillCode)
                .FirstOrDefault();
            Base_NumberRule numberRule = _numberRuleRepository.FindAsIQueryable(x => x.FormCode == "InStoreForm")
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
