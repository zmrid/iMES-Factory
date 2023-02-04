/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Ware_OutWareHouseBill",Enums.ActionPermissionOptions.Search)]
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
    public partial class Ware_OutWareHouseBillController
    {
        private readonly IWare_OutWareHouseBillService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWare_OutWareHouseBillListRepository _outWareHouseBillListRepository;

        [ActivatorUtilitiesConstructor]
        public Ware_OutWareHouseBillController(
            IWare_OutWareHouseBillService service,
            IHttpContextAccessor httpContextAccessor,
            IWare_OutWareHouseBillListRepository outWareHouseBillListRepository
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _outWareHouseBillListRepository = outWareHouseBillListRepository;
        }

        /// <summary>
        /// 获取出库单产品明细列表
        /// </summary>
        /// <param name="WareHouseBill_Id">出库单号</param>
        /// <returns></returns>
        [Route("getDetailRows"), HttpGet]
        public async Task<IActionResult> GetDetailRows(int OutWareHouseBill_Id)
        {
            var rows = await _outWareHouseBillListRepository.FindAsIQueryable(x => x.OutWareHouseBill_Id == OutWareHouseBill_Id)
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
