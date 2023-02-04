/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_ProductionReportController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Report.IServices;
namespace iMES.Report.Controllers
{
    [Route("api/View_ProductionReport")]
    [PermissionTable(Name = "View_ProductionReport")]
    public partial class View_ProductionReportController : ApiBaseController<IView_ProductionReportService>
    {
        public View_ProductionReportController(IView_ProductionReportService service)
        : base(service)
        {
        }
    }
}

