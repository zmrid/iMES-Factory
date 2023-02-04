/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Quality_TemplateProductController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Quality.IServices;
namespace iMES.Quality.Controllers
{
    [Route("api/Quality_TemplateProduct")]
    [PermissionTable(Name = "Quality_TemplateProduct")]
    public partial class Quality_TemplateProductController : ApiBaseController<IQuality_TemplateProductService>
    {
        public Quality_TemplateProductController(IQuality_TemplateProductService service)
        : base(service)
        {
        }
    }
}

