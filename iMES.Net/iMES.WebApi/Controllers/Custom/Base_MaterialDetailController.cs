/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Base_MaterialDetailController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Custom.IServices;
namespace iMES.Custom.Controllers
{
    [Route("api/Base_MaterialDetail")]
    [PermissionTable(Name = "Base_MaterialDetail")]
    public partial class Base_MaterialDetailController : ApiBaseController<IBase_MaterialDetailService>
    {
        public Base_MaterialDetailController(IBase_MaterialDetailService service)
        : base(service)
        {
        }
    }
}

