/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Quality_Template",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Quality.IServices;
using iMES.Core.Filters;
using iMES.Core.Enums;
using iMES.Quality.Services;

namespace iMES.Quality.Controllers
{
    public partial class Quality_TemplateController
    {
        private readonly IQuality_TemplateService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Quality_TemplateController(
            IQuality_TemplateService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }
        //ApiActionPermission("Equip_SpotMaintPlan", ActionPermissionOptions.Search)设置查询表的权限，如果不填写只要登陆了都可以查询
        /// <summary>
        /// 获取table1的数据
        /// </summary>
        /// <param name="loadData"></param>
        /// <returns></returns>
        [Route("getTable1Data"), HttpPost, ApiActionPermission("Quality_Template", ActionPermissionOptions.Search)]
        public async Task<IActionResult> GetTable1Data([FromBody] PageDataOptions loadData)
        {
            return JsonNormal(await Service.GetTable1Data(loadData));
        }

        /// <summary>
        /// 获取table1的数据
        /// </summary>
        /// <param name="loadData"></param>
        /// <returns></returns>
        [Route("getTable2Data"), HttpPost, ApiActionPermission("Quality_Template", ActionPermissionOptions.Search)]
        public async Task<IActionResult> GetTable2Data([FromBody] PageDataOptions loadData)
        {
            return JsonNormal(await Service.GetTable2Data(loadData));
        }
        [HttpPost, Route("getSelectorTemplate")]
        public IActionResult getSelectorTemplate([FromBody] PageDataOptions options)
        {
            //1.可以直接调用框架的GetPageData查询
            PageGridData<Quality_Template> data = Quality_TemplateService.Instance.GetPageData(options);
            return JsonNormal(data);
        }
    }
}
