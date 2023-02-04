/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Base_Process",Enums.ActionPermissionOptions.Search)]
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
using iMES.Custom.Services;
using iMES.Core.DBManager;
using iMES.Core.Filters;
using Microsoft.AspNetCore.Authorization;

namespace iMES.Custom.Controllers
{
    public partial class Base_ProcessController
    {
        private readonly IBase_ProcessService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBase_ProcessListRepository _processListRepository;

        [ActivatorUtilitiesConstructor]
        public Base_ProcessController(
            IBase_ProcessService service,
            IHttpContextAccessor httpContextAccessor,
            IBase_ProcessListRepository processListRepository
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _processListRepository = processListRepository;
        }

        /// <summary>
        /// 获取工序数据采集信息列表
        /// </summary>
        /// <param name="Process_Id">工序</param>
        /// <returns></returns>
        [Route("getDetailRows"), HttpGet]
        public async Task<IActionResult> GetDetailRows(int Process_Id)
        {
            var rows = await _processListRepository.FindAsIQueryable(x => x.Process_Id == Process_Id)
                  .ToListAsync();
            return JsonNormal(rows);
        }
        /// <summary>
        /// 获取工序数据采集信息列表
        /// </summary>
        /// <param name="Process_Id">工序</param>
        /// <returns></returns>
        [Route("getProcessListByLineID"), HttpGet]
        public JsonResult GetProcessListByLineID(int ProcessLine_Id)
        {
            return JsonNormal(_service.GetProcessListByLineID(ProcessLine_Id));
        }

        //后台中添加代码，返回table数据
        [HttpPost, Route("getSelectorProcess")]
        public IActionResult GetSelectorProcess([FromBody] PageDataOptions options)
        {
            //1.可以直接调用框架的GetPageData查询
            PageGridData<Base_Process> data = Base_ProcessService.Instance.GetPageData(options);
            return JsonNormal(data);
        }

        /// <summary>
        /// APP统计报表工序计划数
        /// </summary>
        /// <returns></returns>
        [Route("getAppHomeProcessTop5"), HttpGet]
        [AllowAnonymous]
        public JsonResult GetAppHomeProcessTop5()
        {
            string woSql = @" SELECT TOP 5   [ProcessName] name, SUM([PlanQty]) data
                                         FROM[iMES].[dbo].[Production_WorkOrderList]  GROUP BY ProcessName ";
            List<BoardEntity> list = DBServerProvider.SqlDapper.QueryList<BoardEntity>(woSql, new { });
            return JsonNormal(list);
        }
    }
}
