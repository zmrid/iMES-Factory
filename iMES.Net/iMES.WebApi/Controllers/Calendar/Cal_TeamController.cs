/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Cal_TeamController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Calendar.IServices;
namespace iMES.Calendar.Controllers
{
    [Route("api/Cal_Team")]
    [PermissionTable(Name = "Cal_Team")]
    public partial class Cal_TeamController : ApiBaseController<ICal_TeamService>
    {
        public Cal_TeamController(ICal_TeamService service)
        : base(service)
        {
        }
    }
}

