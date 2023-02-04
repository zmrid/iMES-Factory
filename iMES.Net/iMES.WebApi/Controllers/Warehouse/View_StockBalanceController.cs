/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_StockBalanceController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Warehouse.IServices;
namespace iMES.Warehouse.Controllers
{
    [Route("api/View_StockBalance")]
    [PermissionTable(Name = "View_StockBalance")]
    public partial class View_StockBalanceController : ApiBaseController<IView_StockBalanceService>
    {
        public View_StockBalanceController(IView_StockBalanceService service)
        : base(service)
        {
        }
    }
}

