/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Ware_OutWareHouseBillListController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Warehouse.IServices;
namespace iMES.Warehouse.Controllers
{
    [Route("api/Ware_OutWareHouseBillList")]
    [PermissionTable(Name = "Ware_OutWareHouseBillList")]
    public partial class Ware_OutWareHouseBillListController : ApiBaseController<IWare_OutWareHouseBillListService>
    {
        public Ware_OutWareHouseBillListController(IWare_OutWareHouseBillListService service)
        : base(service)
        {
        }
    }
}

