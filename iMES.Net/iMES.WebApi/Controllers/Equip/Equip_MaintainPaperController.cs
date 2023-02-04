/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Equip_MaintainPaperController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Equip.IServices;
namespace iMES.Equip.Controllers
{
    [Route("api/Equip_MaintainPaper")]
    [PermissionTable(Name = "Equip_MaintainPaper")]
    public partial class Equip_MaintainPaperController : ApiBaseController<IEquip_MaintainPaperService>
    {
        public Equip_MaintainPaperController(IEquip_MaintainPaperService service)
        : base(service)
        {
        }
    }
}

