/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Equip_SpotMaintPlanDeviceController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Equip.IServices;
namespace iMES.Equip.Controllers
{
    [Route("api/Equip_SpotMaintPlanDevice")]
    [PermissionTable(Name = "Equip_SpotMaintPlanDevice")]
    public partial class Equip_SpotMaintPlanDeviceController : ApiBaseController<IEquip_SpotMaintPlanDeviceService>
    {
        public Equip_SpotMaintPlanDeviceController(IEquip_SpotMaintPlanDeviceService service)
        : base(service)
        {
        }
    }
}

