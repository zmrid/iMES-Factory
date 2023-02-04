/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Base_DefectItem",Enums.ActionPermissionOptions.Search)]
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
using iMES.Core.Filters;
using Microsoft.AspNetCore.Authorization;

namespace iMES.Custom.Controllers
{
    public partial class Base_DefectItemController
    {
        private readonly IBase_DefectItemService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Base_DefectItemController(
            IBase_DefectItemService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// 获取首页工序数量明细信息
        /// </summary>
        /// <returns></returns>
        [Route("getAppHomeDefectValue"), HttpGet]
        [AllowAnonymous]
        public JsonResult GetAppHomeDefectValue()
        {
            string woSql = " select * from HomeView_App_GetDefectValue ";
            List<BoardEntity> list = DBServerProvider.SqlDapper.QueryList<BoardEntity>(woSql, new { });
            return JsonNormal(list);
        }
    }
}
