/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Cal_PlanController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Calendar.IServices;
namespace iMES.Calendar.Controllers
{
    [Route("api/Cal_Plan")]
    [PermissionTable(Name = "Cal_Plan")]
    public partial class Cal_PlanController : ApiBaseController<ICal_PlanService>
    {
        public Cal_PlanController(ICal_PlanService service)
        : base(service)
        {
        }
    }
}

