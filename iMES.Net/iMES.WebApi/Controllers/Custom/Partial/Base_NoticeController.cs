/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Base_Notice",Enums.ActionPermissionOptions.Search)]
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
    public partial class Base_NoticeController
    {
        private readonly IBase_NoticeService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Base_NoticeController(
            IBase_NoticeService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// 获取通知列表
        /// </summary>
        /// <returns></returns>
        [Route("getList"), HttpGet]
        public JsonResult GetList()
        {
            string woSql = " select top 10  NoticeTitle title,CreateDate date,NoticeContent message from Base_Notice order by CreateDate DESC ";
            List<NoticeOutput> list = DBServerProvider.SqlDapper.QueryList<NoticeOutput>(woSql, new { });
            return JsonNormal(list);
        }
    }
}
