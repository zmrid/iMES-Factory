/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Equip_SpotMaintWorkOrder",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Equip.IServices;
using iMES.Core.Filters;
using iMES.Equip.IRepositories;

namespace iMES.Equip.Controllers
{
    public partial class Equip_SpotMaintWorkOrderController
    {
        private readonly IEquip_SpotMaintWorkOrderService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEquip_SpotMaintWorkOrderRepository _spotMaintWorkOrderRepository;

        [ActivatorUtilitiesConstructor]
        public Equip_SpotMaintWorkOrderController(
            IEquip_SpotMaintWorkOrderService service,
            IHttpContextAccessor httpContextAccessor,
            IEquip_SpotMaintWorkOrderRepository spotMaintWorkOrderRepository
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _spotMaintWorkOrderRepository = spotMaintWorkOrderRepository;
        }

        /// <summary>
        /// 定时任务生成点检保养工单
        /// </summary>
        /// <returns></returns>
        [ApiTask]
        [HttpGet, HttpPost, Route("generateSpotWorkOrder")]
        public IActionResult GenerateSpotWorkOrder()
        {
            return Content(_service.CreateSpotWorkOrder());
        }

        /// <summary>
        /// 工单状态变更
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet, Route("changeUpdate")]
        public string ChangeUpdate(string spotMaintWorkOrderId, string status,string remark)
        {
            Equip_SpotMaintWorkOrder workOrder = new Equip_SpotMaintWorkOrder()
            {
                SpotMaintWorkOrderId = new Guid(spotMaintWorkOrderId),
                Status =  Convert.ToInt32(status),
                Remark = remark,
                ModifyDate = DateTime.Now,
            };
            _spotMaintWorkOrderRepository.Update(workOrder, x => new { x.Status, x.ModifyDate, x.Remark }, true);
            return "变更成功！";
        }
    }
}
