/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Sys_VersionInfo",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.System.IServices;
using iMES.Core.DBManager;

namespace iMES.System.Controllers
{
    public partial class Sys_VersionInfoController
    {
        private readonly ISys_VersionInfoService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Sys_VersionInfoController(
            ISys_VersionInfoService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 获取首页版本更新记录
        /// </summary>
        /// <returns></returns>
        [Route("getVersionInfo"), HttpGet]
        public JsonResult GetVersionInfo()
        {
            string sql = " select top 8 * from Sys_VersionInfo order by CreateDate desc ";
            List<Sys_VersionInfo> list = DBServerProvider.SqlDapper.QueryList<Sys_VersionInfo>(sql, new { });
            return Json(list);
        }
    }
}
