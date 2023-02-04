/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_OutputStatisticsController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Report.IServices;
namespace iMES.Report.Controllers
{
    [Route("api/View_OutputStatistics")]
    [PermissionTable(Name = "View_OutputStatistics")]
    public partial class View_OutputStatisticsController : ApiBaseController<IView_OutputStatisticsService>
    {
        public View_OutputStatisticsController(IView_OutputStatisticsService service)
        : base(service)
        {
        }
    }
}

