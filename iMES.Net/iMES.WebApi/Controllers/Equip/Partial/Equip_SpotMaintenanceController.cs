/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Equip_SpotMaintenance",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Equip.IServices;
using iMES.Equip.Services;

namespace iMES.Equip.Controllers
{
    public partial class Equip_SpotMaintenanceController
    {
        private readonly IEquip_SpotMaintenanceService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Equip_SpotMaintenanceController(
            IEquip_SpotMaintenanceService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost, Route("getSelectorSpotMaintenance")]
        public IActionResult getSelectorSpotMaintenance([FromBody] PageDataOptions options)
        {
            //1.可以直接调用框架的GetPageData查询
            PageGridData<Equip_SpotMaintenance> data = Equip_SpotMaintenanceService.Instance.GetPageData(options);
            return JsonNormal(data);
        }
    }
}
