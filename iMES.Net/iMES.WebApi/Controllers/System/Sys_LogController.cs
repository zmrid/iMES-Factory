using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iMES.Core.Controllers.Basic;
using iMES.Core.DBManager;
using iMES.Entity.DomainModels;
using iMES.System.IServices;

namespace iMES.System.Controllers
{
    [Route("api/Sys_Log")]
    public partial class Sys_LogController : ApiBaseController<ISys_LogService>
    {
        public Sys_LogController(ISys_LogService service)
        : base("System", "System", "Sys_Log", service)
        {
        }
        [Route("test"), AllowAnonymous, HttpGet]
        public IActionResult Test()
        {
            string mess = "";
            try
            {
                List<Sys_Log> list = new List<Sys_Log>();
                for (int i = 0; i < 10; i++)
                {
                    list.Add(new Sys_Log()
                    {
                        BeginDate = DateTime.Now,
                        RequestParameter = i + ""
                    }); ;
                }
                DBServerProvider.SqlDapper.AddRange<Sys_Log>(list);
                //  DBServerProvider.SqlDapper.BulkInsert<Sys_Log>(list);
            }
            catch (Exception ex)
            {

                mess = ex.Message + ex.StackTrace;
            }
            return Content("11" + mess);

        }
    }
}
