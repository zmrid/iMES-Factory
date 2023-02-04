using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using iMES.Core.Controllers.Basic;
using iMES.Core.Extensions;
using iMES.Core.Filters;
using iMES.System.IServices;

namespace iMES.System.Controllers
{
    [Route("api/Sys_Dictionary")]
    public partial class Sys_DictionaryController : ApiBaseController<ISys_DictionaryService>
    {
        public Sys_DictionaryController(ISys_DictionaryService service)
        : base("System", "System", "Sys_Dictionary", service)
        {
        }
    }
}
