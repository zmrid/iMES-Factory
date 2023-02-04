/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Tools_ToolsReceiveController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Tools.IServices;
namespace iMES.Tools.Controllers
{
    [Route("api/Tools_ToolsReceive")]
    [PermissionTable(Name = "Tools_ToolsReceive")]
    public partial class Tools_ToolsReceiveController : ApiBaseController<ITools_ToolsReceiveService>
    {
        public Tools_ToolsReceiveController(ITools_ToolsReceiveService service)
        : base(service)
        {
        }
    }
}

