/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Equip_DevCatalogController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Equip.IServices;
namespace iMES.Equip.Controllers
{
    [Route("api/Equip_DevCatalog")]
    [PermissionTable(Name = "Equip_DevCatalog")]
    public partial class Equip_DevCatalogController : ApiBaseController<IEquip_DevCatalogService>
    {
        public Equip_DevCatalogController(IEquip_DevCatalogService service)
        : base(service)
        {
        }
    }
}

