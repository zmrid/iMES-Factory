/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Equip_SpotMaintWorkOrderController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Equip.IServices;
namespace iMES.Equip.Controllers
{
    [Route("api/Equip_SpotMaintWorkOrder")]
    [PermissionTable(Name = "Equip_SpotMaintWorkOrder")]
    public partial class Equip_SpotMaintWorkOrderController : ApiBaseController<IEquip_SpotMaintWorkOrderService>
    {
        public Equip_SpotMaintWorkOrderController(IEquip_SpotMaintWorkOrderService service)
        : base(service)
        {
        }
    }
}

