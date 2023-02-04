/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Quality_ProcessCheckController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Quality.IServices;
namespace iMES.Quality.Controllers
{
    [Route("api/Quality_ProcessCheck")]
    [PermissionTable(Name = "Quality_ProcessCheck")]
    public partial class Quality_ProcessCheckController : ApiBaseController<IQuality_ProcessCheckService>
    {
        public Quality_ProcessCheckController(IQuality_ProcessCheckService service)
        : base(service)
        {
        }
    }
}

