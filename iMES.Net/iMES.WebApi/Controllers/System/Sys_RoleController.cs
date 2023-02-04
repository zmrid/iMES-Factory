using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using iMES.Core.Controllers.Basic;
using iMES.Core.Enums;
using iMES.Core.Filters;
using iMES.Entity.AttributeManager;
using iMES.Entity.DomainModels;
using iMES.System.IServices;

namespace iMES.System.Controllers
{
    [Route("api/Sys_Role")]
    [PermissionTable(Name = "Sys_Role")]
    public partial class Sys_RoleController : ApiBaseController<ISys_RoleService>
    {
        public Sys_RoleController(ISys_RoleService service)
        : base("System", "System", "Sys_Role", service)
        {

        }
    }
}


