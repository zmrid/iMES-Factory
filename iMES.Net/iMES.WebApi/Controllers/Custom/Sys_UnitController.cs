/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Sys_UnitController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Custom.IServices;
namespace iMES.Custom.Controllers
{
    [Route("api/Sys_Unit")]
    [PermissionTable(Name = "Sys_Unit")]
    public partial class Sys_UnitController : ApiBaseController<ISys_UnitService>
    {
        public Sys_UnitController(ISys_UnitService service)
        : base(service)
        {
        }
    }
}

