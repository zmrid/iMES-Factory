/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Ware_WareHouseBillListController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Warehouse.IServices;
namespace iMES.Warehouse.Controllers
{
    [Route("api/Ware_WareHouseBillList")]
    [PermissionTable(Name = "Ware_WareHouseBillList")]
    public partial class Ware_WareHouseBillListController : ApiBaseController<IWare_WareHouseBillListService>
    {
        public Ware_WareHouseBillListController(IWare_WareHouseBillListService service)
        : base(service)
        {
        }
    }
}

