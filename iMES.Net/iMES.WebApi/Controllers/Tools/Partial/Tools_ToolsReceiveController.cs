/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Tools_ToolsReceive",Enums.ActionPermissionOptions.Search)]
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
    public partial class Tools_ToolsReceiveController
    {
        private readonly ITools_ToolsReceiveService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITools_ToolsReceiveListRepository _toolsReceiveListRepository;

        [ActivatorUtilitiesConstructor]
        public Tools_ToolsReceiveController(
            ITools_ToolsReceiveService service,
            IHttpContextAccessor httpContextAccessor,
            ITools_ToolsReceiveListRepository toolsReceiveListRepository
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _toolsReceiveListRepository = toolsReceiveListRepository;
        }
        /// <summary>
        /// 获取领用单工装夹具明细列表
        /// </summary>
        /// <param name="ToolsReceiveId">工装领用主键</param>
        /// <returns></returns>
        [Route("getDetailRows"), HttpGet]
        public async Task<IActionResult> GetDetailRows(int ToolsReceiveId)
        {
            var rows = await _toolsReceiveListRepository.FindAsIQueryable(x => x.ToolsReceiveId == ToolsReceiveId)
                  .ToListAsync();
            return JsonNormal(rows);
        }
    }
}
