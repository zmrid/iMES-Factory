/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Quality_TemplateController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Quality.IServices;
namespace iMES.Quality.Controllers
{
    [Route("api/Quality_Template")]
    [PermissionTable(Name = "Quality_Template")]
    public partial class Quality_TemplateController : ApiBaseController<IQuality_TemplateService>
    {
        public Quality_TemplateController(IQuality_TemplateService service)
        : base(service)
        {
        }
    }
}

