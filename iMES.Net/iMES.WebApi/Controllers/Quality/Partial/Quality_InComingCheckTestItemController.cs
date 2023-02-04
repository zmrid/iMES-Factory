/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Quality_InComingCheckTestItem",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Quality.IServices;

namespace iMES.Quality.Controllers
{
    public partial class Quality_InComingCheckTestItemController
    {
        private readonly IQuality_InComingCheckTestItemService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Quality_InComingCheckTestItemController(
            IQuality_InComingCheckTestItemService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
