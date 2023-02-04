/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Tools_Tool",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Tools.IServices;
using iMES.Tools.Services;

namespace iMES.Tools.Controllers
{
    public partial class Tools_ToolController
    {
        private readonly ITools_ToolService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Tools_ToolController(
            ITools_ToolService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }
        //后台App_ProductController中添加代码，返回table数据
        [HttpPost, Route("getSelectorTools")]
        public IActionResult GetSelectorTools([FromBody] PageDataOptions options)
        {
            //1.可以直接调用框架的GetPageData查询
            PageGridData<Tools_Tool> data = Tools_ToolService.Instance.GetPageData(options);
            return JsonNormal(data);
        }
    }
}
