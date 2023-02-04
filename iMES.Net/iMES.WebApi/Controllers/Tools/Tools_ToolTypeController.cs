/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Tools_ToolTypeController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Tools.IServices;
namespace iMES.Tools.Controllers
{
    [Route("api/Tools_ToolType")]
    [PermissionTable(Name = "Tools_ToolType")]
    public partial class Tools_ToolTypeController : ApiBaseController<ITools_ToolTypeService>
    {
        public Tools_ToolTypeController(ITools_ToolTypeService service)
        : base(service)
        {
        }
    }
}

