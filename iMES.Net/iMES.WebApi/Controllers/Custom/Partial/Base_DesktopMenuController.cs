/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Base_DesktopMenu",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Custom.IServices;
using iMES.Core.DBManager;

namespace iMES.Custom.Controllers
{
    public partial class Base_DesktopMenuController
    {
        private readonly IBase_DesktopMenuService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Base_DesktopMenuController(
            IBase_DesktopMenuService service,
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
        [Route("getDesktopMenu"), HttpGet]
        public JsonResult GetDesktopMenu()
        {
            string sql = " select top 8 * from Base_DesktopMenu where Enable=1 order by CreateDate desc ";
            List<Base_DesktopMenu> list = DBServerProvider.SqlDapper.QueryList<Base_DesktopMenu>(sql, new { });
            return JsonNormal(list);
        }
    }
}
