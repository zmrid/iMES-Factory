/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Quality_TemplateTestItem",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Quality.IServices;
using iMES.Quality.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace iMES.Quality.Controllers
{
    public partial class Quality_TemplateTestItemController
    {
        private readonly IQuality_TemplateTestItemService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IQuality_TemplateTestItemRepository _templateTestItem;
        private readonly IQuality_TemplateProductRepository _templateProduct;
        private readonly IQuality_TemplateRepository _template;

        [ActivatorUtilitiesConstructor]
        public Quality_TemplateTestItemController(
            IQuality_TemplateTestItemService service,
            IHttpContextAccessor httpContextAccessor,
            IQuality_TemplateTestItemRepository templateTestItem,
            IQuality_TemplateProductRepository templateProduct,
            IQuality_TemplateRepository template
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _templateTestItem = templateTestItem;
            _templateProduct = templateProduct;
            _template = template;
        }
        /// <summary>
        /// 来料检验单根据产品主键获取测试项
        /// </summary>
        /// <param name="SalesOrder_Id">产品主键</param>
        /// <returns></returns>
        [Route("getTestItemRows"), HttpGet]
        public async Task<IActionResult> GetTestItemRows(int ProductId)
        {
            int templateId = _templateProduct.FindAsIQueryable(x => x.ProductId == ProductId)
                 .OrderByDescending(x => x.CreateDate)
                 .Select(s => s.TemplateId)
                 .FirstOrDefault();
            templateId = _template.FindAsIQueryable(x => x.TemplateId == templateId && x.QcType.Contains("LLJY") && x.Enable == 1)
                .OrderByDescending(x => x.CreateDate)
                .Select(s => s.TemplateId)
                .FirstOrDefault();
            if (templateId != 0)
            {
                var rows = await _templateTestItem.FindAsIQueryable(x => x.TemplateId == templateId)
                   .ToListAsync();
                //获取当前库存数量
                return JsonNormal(rows);
            }
            else
            {
                return JsonNormal("[]");
            }
        }
        /// <summary>
        /// 出货检验单根据产品主键获取测试项
        /// </summary>
        /// <param name="SalesOrder_Id">产品主键</param>
        /// <returns></returns>
        [Route("getOutCheckTestItemRows"), HttpGet]
        public async Task<IActionResult> GetOutCheckTestItemRows(int ProductId)
        {
            int templateId = _templateProduct.FindAsIQueryable(x => x.ProductId == ProductId)
                 .OrderByDescending(x => x.CreateDate)
                 .Select(s => s.TemplateId)
                 .FirstOrDefault();
            templateId = _template.FindAsIQueryable(x => x.TemplateId == templateId && x.QcType.Contains("FHJY") && x.Enable == 1)
                .OrderByDescending(x => x.CreateDate)
                .Select(s => s.TemplateId)
                .FirstOrDefault();
            if (templateId != 0)
            {
                var rows = await _templateTestItem.FindAsIQueryable(x => x.TemplateId == templateId)
                   .ToListAsync();
                //获取当前库存数量
                return JsonNormal(rows);
            }
            else
            {
                return JsonNormal("[]");
            }
        }
        /// <summary>
        /// 过程检验单根据产品主键获取测试项
        /// </summary>
        /// <param name="SalesOrder_Id">产品主键</param>
        /// <returns></returns>
        [Route("getProcessTestItemRows"), HttpGet]
        public async Task<IActionResult> GetProcessTestItemRows(int ProductId)
        {
            int templateId = _templateProduct.FindAsIQueryable(x => x.ProductId == ProductId)
                 .OrderByDescending(x => x.CreateDate)
                 .Select(s => s.TemplateId)
                 .FirstOrDefault();
            templateId = _template.FindAsIQueryable(x => x.TemplateId == templateId && (x.QcType.Contains("CPJY")|| x.QcType.Contains("SJ") || x.QcType.Contains("XJ") || x.QcType.Contains("MJ")) && x.Enable == 1)
                .OrderByDescending(x => x.CreateDate)
                .Select(s => s.TemplateId)
                .FirstOrDefault();
            if (templateId != 0)
            {
                var rows = await _templateTestItem.FindAsIQueryable(x => x.TemplateId == templateId)
                   .ToListAsync();
                //获取当前库存数量
                return JsonNormal(rows);
            }
            else
            {
                return JsonNormal("[]");
            }
        }
    }
}
