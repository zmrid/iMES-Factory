/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Base_ProcessLineController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Custom.IServices;
namespace iMES.Custom.Controllers
{
    [Route("api/Base_ProcessLine")]
    [PermissionTable(Name = "Base_ProcessLine")]
    public partial class Base_ProcessLineController : ApiBaseController<IBase_ProcessLineService>
    {
        public Base_ProcessLineController(IBase_ProcessLineService service)
        : base(service)
        {
        }
    }
}

