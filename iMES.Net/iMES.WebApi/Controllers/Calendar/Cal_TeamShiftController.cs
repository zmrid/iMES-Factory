/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Cal_TeamShiftController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Calendar.IServices;
namespace iMES.Calendar.Controllers
{
    [Route("api/Cal_TeamShift")]
    [PermissionTable(Name = "Cal_TeamShift")]
    public partial class Cal_TeamShiftController : ApiBaseController<ICal_TeamShiftService>
    {
        public Cal_TeamShiftController(ICal_TeamShiftService service)
        : base(service)
        {
        }
    }
}

