/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Cal_PlanShiftController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Calendar.IServices;
namespace iMES.Calendar.Controllers
{
    [Route("api/Cal_PlanShift")]
    [PermissionTable(Name = "Cal_PlanShift")]
    public partial class Cal_PlanShiftController : ApiBaseController<ICal_PlanShiftService>
    {
        public Cal_PlanShiftController(ICal_PlanShiftService service)
        : base(service)
        {
        }
    }
}

