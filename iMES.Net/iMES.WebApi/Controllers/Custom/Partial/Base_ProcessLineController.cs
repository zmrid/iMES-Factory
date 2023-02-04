/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Base_ProcessLine",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Custom.IServices;
using iMES.Custom.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace iMES.Custom.Controllers
{
    public partial class Base_ProcessLineController
    {
        private readonly IBase_ProcessLineService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBase_ProcessLineListRepository _processLineListRepository;

        [ActivatorUtilitiesConstructor]
        public Base_ProcessLineController(
            IBase_ProcessLineService service,
            IHttpContextAccessor httpContextAccessor,
            IBase_ProcessLineListRepository processLineListRepository
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _processLineListRepository = processLineListRepository;
        }
        /// <summary>
        /// 获取工序数据采集信息列表
        /// </summary>
        /// <param name="Process_Id">工序</param>
        /// <returns></returns>
        [Route("getDetailRows"), HttpGet]
        public async Task<IActionResult> GetDetailRows(int ProcessLine_Id)
        {
            var rows = await _processLineListRepository.FindAsIQueryable(x => x.ProcessLine_Id == ProcessLine_Id)
                  .ToListAsync();
            return JsonNormal(rows);
        }
    }
}
