/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Quality_OutCheckController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Quality.IServices;
namespace iMES.Quality.Controllers
{
    [Route("api/Quality_OutCheck")]
    [PermissionTable(Name = "Quality_OutCheck")]
    public partial class Quality_OutCheckController : ApiBaseController<IQuality_OutCheckService>
    {
        public Quality_OutCheckController(IQuality_OutCheckService service)
        : base(service)
        {
        }
    }
}

