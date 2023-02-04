/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Equip_SpotMaintPlanController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Equip.IServices;
namespace iMES.Equip.Controllers
{
    [Route("api/Equip_SpotMaintPlan")]
    [PermissionTable(Name = "Equip_SpotMaintPlan")]
    public partial class Equip_SpotMaintPlanController : ApiBaseController<IEquip_SpotMaintPlanService>
    {
        public Equip_SpotMaintPlanController(IEquip_SpotMaintPlanService service)
        : base(service)
        {
        }
    }
}

