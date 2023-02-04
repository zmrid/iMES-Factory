/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Tools_ToolsReturn",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Tools.IServices;
using iMES.Tools.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace iMES.Tools.Controllers
{
    public partial class Tools_ToolsReturnController
    {
        private readonly ITools_ToolsReturnService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITools_ToolsReturnListRepository _toolsReturnListRepository;

        [ActivatorUtilitiesConstructor]
        public Tools_ToolsReturnController(
            ITools_ToolsReturnService service,
            IHttpContextAccessor httpContextAccessor,
           ITools_ToolsReturnListRepository toolsReturnListRepository
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _toolsReturnListRepository = toolsReturnListRepository;
        }
        /// <summary>
        /// 获取领用单工装夹具明细列表
        /// </summary>
        /// <param name="ToolsReceiveId">工装领用主键</param>
        /// <returns></returns>
        [Route("getDetailRows"), HttpGet]
        public async Task<IActionResult> GetDetailRows(int ToolsReturnId)
        {
            var rows = await _toolsReturnListRepository.FindAsIQueryable(x => x.ToolsReturnId == ToolsReturnId)
                  .ToListAsync();
            return JsonNormal(rows);
        }
    }
}
