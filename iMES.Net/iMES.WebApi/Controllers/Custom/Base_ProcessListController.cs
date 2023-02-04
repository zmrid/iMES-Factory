/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Base_ProcessListController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Custom.IServices;
namespace iMES.Custom.Controllers
{
    [Route("api/Base_ProcessList")]
    [PermissionTable(Name = "Base_ProcessList")]
    public partial class Base_ProcessListController : ApiBaseController<IBase_ProcessListService>
    {
        public Base_ProcessListController(IBase_ProcessListService service)
        : base(service)
        {
        }
    }
}

