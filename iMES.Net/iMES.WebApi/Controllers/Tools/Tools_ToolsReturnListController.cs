/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Tools_ToolsReturnListController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Tools.IServices;
namespace iMES.Tools.Controllers
{
    [Route("api/Tools_ToolsReturnList")]
    [PermissionTable(Name = "Tools_ToolsReturnList")]
    public partial class Tools_ToolsReturnListController : ApiBaseController<ITools_ToolsReturnListService>
    {
        public Tools_ToolsReturnListController(ITools_ToolsReturnListService service)
        : base(service)
        {
        }
    }
}

