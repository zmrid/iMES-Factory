/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Base_Product",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Custom.IServices;
using iMES.Custom.Services;
using iMES.Core.Filters;
using iMES.Core.Enums;

namespace iMES.Custom.Controllers
{
    public partial class Base_ProductController
    {
        private readonly IBase_ProductService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Base_ProductController(
            IBase_ProductService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        //后台App_ProductController中添加代码，返回table数据
        [HttpPost, Route("getSelectorDemo")]
        public IActionResult GetSelectorDemo([FromBody] PageDataOptions options)
        {
            //1.可以直接调用框架的GetPageData查询
            PageGridData<Base_Product> data = Base_ProductService.Instance.GetPageData(options);
            return JsonNormal(data);
        }
        [HttpGet, HttpPost, Route("getProductInfoByProductID")]
        [ApiActionPermission("Base_Product", ActionPermissionOptions.Search)]
        public IActionResult GetProductInfoByProductID(int productId)
        {
            return JsonNormal(_service.GetProductInfoByProductID(productId));
        }
    }
}
