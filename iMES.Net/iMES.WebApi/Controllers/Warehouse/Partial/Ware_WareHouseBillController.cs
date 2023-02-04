/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Ware_WareHouseBill",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Warehouse.IServices;
using iMES.Warehouse.IRepositories;
using Microsoft.EntityFrameworkCore;
using iMES.Custom.Services;

namespace iMES.Warehouse.Controllers
{
    public partial class Ware_WareHouseBillController
    {
        private readonly IWare_WareHouseBillService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWare_WareHouseBillListRepository _wareHouseBillListRepository;

        [ActivatorUtilitiesConstructor]
        public Ware_WareHouseBillController(
            IWare_WareHouseBillService service,
            IHttpContextAccessor httpContextAccessor,
            IWare_WareHouseBillListRepository wareHouseBillListRepository
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _wareHouseBillListRepository = wareHouseBillListRepository;
        }

        /// <summary>
        /// 获取入库单产品明细列表
        /// </summary>
        /// <param name="WareHouseBill_Id">入库单号</param>
        /// <returns></returns>
        [Route("getDetailRows"), HttpGet]
        public async Task<IActionResult> GetDetailRows(int WareHouseBill_Id)
        {
            var rows = await _wareHouseBillListRepository.FindAsIQueryable(x => x.WareHouseBill_Id == WareHouseBill_Id)
                  .ToListAsync();
            //获取当前库存数量
            List<Base_Product> storeList = Base_ProductService.GetStoreNumber();
            for (int i = 0; i < rows.Count; i++)
            {
                if (storeList.Exists(x => x.Product_Id == rows[i].Product_Id))
                {
                    rows[i].InventoryQty = storeList.Find(x => x.Product_Id == rows[i].Product_Id).InventoryQty;
                }
                else
                {
                    rows[i].InventoryQty = 0;
                }
            }
            return JsonNormal(rows);
        }
    }
}
