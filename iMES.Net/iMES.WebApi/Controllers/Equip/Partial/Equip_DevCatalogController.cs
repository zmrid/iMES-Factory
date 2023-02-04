/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Equip_DevCatalog",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Equip.IServices;
using iMES.Core.Filters;
using iMES.Core.Enums;
using iMES.Equip.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using iMES.Core.Extensions;

namespace iMES.Equip.Controllers
{
    public partial class Equip_DevCatalogController
    {
        private readonly IEquip_DevCatalogService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Equip_DevCatalogController(
            IEquip_DevCatalogService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 打印分类tree页面获取左边的tree的分类
        /// </summary>
        /// <returns></returns>
        [Route("getList"), HttpGet]
        public async Task<IActionResult> GetList()
        {
            var data = await Equip_DevCatalogRepository.Instance.FindAsIQueryable(x => true)
                  .Select(s => new
                  {
                      id = s.DevCatalogId,
                      s.ParentId,
                      name = s.DevCatalogName,
                      catalogCode = s.DevCatalogCode
                  })
                  .ToListAsync();
            return Json(data);
        }

        public override ActionResult GetPageData([FromBody] PageDataOptions loadData)
        {
            //没有查询条件显示所有一级节点数据
            if (loadData.Value.GetInt() == 1)
            {
                return GetCatalogRootData(loadData);
            }
            //有查询条件使用框架默认的查询方法
            return base.GetPageData(loadData);
        }

        /// treetable 获取根节点数据
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("getCatalogRootData")]
        [ApiActionPermission(ActionPermissionOptions.Search)]
        public ActionResult GetCatalogRootData([FromBody] PageDataOptions options)
        {
            //页面加载(一级)根节点数据条件x => x.ParentId==null,自己根据需要设置
            var query = Equip_DevCatalogRepository.Instance.FindAsIQueryable(x => x.ParentId == null);

            var rows = query.TakeOrderByPage(options.Page, options.Rows)
                .OrderBy(x => x.DevCatalogName).Select(s => new
                {
                    s.DevCatalogId,
                    s.DevCatalogName,
                    s.DevCatalogCode,
                    s.ParentId,
                    s.Enable,
                    s.Remark,
                    s.CreateID,
                    s.Creator,
                    s.CreateDate,
                    s.ModifyID,
                    s.Modifier,
                    s.ModifyDate,
                    hasChildren = true
                }).ToList();
            return JsonNormal(new { total = query.Count(), rows });
        }

        /// <summary>
        ///treetable 获取子节点数据
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("getChildrenData")]
        [ApiActionPermission(ActionPermissionOptions.Search)]
        public async Task<ActionResult> GetChildrenData(Guid devCatalogId)
        {
            //点击节点时，加载子节点数据
            var devRepository = Equip_DevCatalogRepository.Instance.FindAsIQueryable(x => 1 == 1);

            var rows = await devRepository.Where(x => x.ParentId == devCatalogId)
                .Select(s => new
                {
                    s.DevCatalogId,
                    s.DevCatalogName,
                    s.DevCatalogCode,
                    s.ParentId,
                    s.Enable,
                    s.Remark,
                    s.CreateID,
                    s.Creator,
                    s.CreateDate,
                    s.ModifyID,
                    s.Modifier,
                    s.ModifyDate,
                    hasChildren = devRepository.Any(x => x.ParentId == s.DevCatalogId)
                }).ToListAsync();
            return JsonNormal(new { rows });
        }
    }
}
