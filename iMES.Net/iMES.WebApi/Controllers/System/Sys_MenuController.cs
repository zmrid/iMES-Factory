using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using iMES.Core.Controllers.Basic;
using iMES.Core.Enums;
using iMES.Core.Filters;
using iMES.Entity.DomainModels;
using iMES.System.IServices;

namespace iMES.System.Controllers
{
    [Route("api/menu")]
    [ApiController, JWTAuthorize()]
    public partial class Sys_MenuController : ApiBaseController<ISys_MenuService>
    {
        private ISys_MenuService _service { get; set; }
        public Sys_MenuController(ISys_MenuService service) :
            base("System", "System", "Sys_Menu", service)
        {
            _service = service;
        } 
    }
}
