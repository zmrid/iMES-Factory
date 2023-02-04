/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹View_DefectItemDistributeController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Report.IServices;
namespace iMES.Report.Controllers
{
    [Route("api/View_DefectItemDistribute")]
    [PermissionTable(Name = "View_DefectItemDistribute")]
    public partial class View_DefectItemDistributeController : ApiBaseController<IView_DefectItemDistributeService>
    {
        public View_DefectItemDistributeController(IView_DefectItemDistributeService service)
        : base(service)
        {
        }
    }
}

