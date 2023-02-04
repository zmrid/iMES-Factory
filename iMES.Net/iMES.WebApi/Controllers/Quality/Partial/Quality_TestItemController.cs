/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Quality_TestItem",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Quality.IServices;
using iMES.Quality.Services;

namespace iMES.Quality.Controllers
{
    public partial class Quality_TestItemController
    {
        private readonly IQuality_TestItemService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Quality_TestItemController(
            IQuality_TestItemService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost, Route("getSelectorTestItem")]
        public IActionResult GetSelectorTestItem([FromBody] PageDataOptions options)
        {
            //1.可以直接调用框架的GetPageData查询
            PageGridData<Quality_TestItem> data = Quality_TestItemService.Instance.GetPageData(options);
            return JsonNormal(data);
        }
    }
}
