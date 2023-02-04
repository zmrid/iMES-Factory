/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Ware_WareHouseBillController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Warehouse.IServices;
namespace iMES.Warehouse.Controllers
{
    [Route("api/Ware_WareHouseBill")]
    [PermissionTable(Name = "Ware_WareHouseBill")]
    public partial class Ware_WareHouseBillController : ApiBaseController<IWare_WareHouseBillService>
    {
        public Ware_WareHouseBillController(IWare_WareHouseBillService service)
        : base(service)
        {
        }
    }
}

