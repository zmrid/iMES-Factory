/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Sys_Dept",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.System.IServices;
using iMES.System.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace iMES.System.Controllers
{
    public partial class Sys_DeptController
    {
        private readonly ISys_DeptService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Sys_DeptController(
            ISys_DeptService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 用户列表左侧tree所有的部门分类
        /// </summary>
        /// <returns></returns>
        [Route("getList"), HttpGet]
        public async Task<IActionResult> GetList()
        {
            var data = await Sys_DeptRepository.Instance.FindAsIQueryable(x => true)
                  .Select(s => new
                  {
                      id = s.Dept_Id,
                      ParentId = 0,
                      name = s.DeptName,
                      catalogCode = s.DeptCode
                  })
                  .ToListAsync();
            return Json(data);
        }
    }
}
