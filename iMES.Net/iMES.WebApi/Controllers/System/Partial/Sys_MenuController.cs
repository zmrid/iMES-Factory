﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using iMES.Core.Enums;
using iMES.Core.Filters;
using iMES.Entity.DomainModels;
using iMES.System.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace iMES.System.Controllers
{
    public partial class Sys_MenuController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost, Route("getTreeMenu")]
        //2019.10.24屏蔽用户查询自己权限菜单
        // [ApiActionPermission("Sys_Menu", ActionPermissionOptions.Search)]
        public async Task<IActionResult> GetTreeMenu()
        {
            return Json(await _service.GetCurrentMenuActionList());
        }
        [HttpPost, Route("getMenu")]
        [ApiActionPermission("Sys_Menu", ActionPermissionOptions.Search)]
        public async Task<IActionResult> GetMenu()
        {
            return Json(await _service.GetMenu());
        }

        [HttpGet,HttpPost, Route("getTreeItem")]
        [ApiActionPermission("Sys_Menu", "1", ActionPermissionOptions.Search)]
        public async Task<IActionResult> GetTreeItem(int menuId)
        {
            return Json(await _service.GetTreeItem(menuId));
        }

        //[ActionPermission("Sys_Menu", "1", ActionPermissionOptions.Add)]
        //只有角色ID为1的才能进行保存操作
        [HttpPost, Route("save"), ApiActionPermission(ActionRolePermission.SuperAdmin)]
        public async Task<ActionResult> Save([FromBody] Sys_Menu menu)
        {
            return Json(await _service.Save(menu));
        }

        /// <summary>
        /// 限制只能超级管理员才删除菜单 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        [ApiActionPermission(ActionRolePermission.SuperAdmin)]
        [HttpPost, Route("delMenu")]
        public async Task<ActionResult> DelMenu(int menuId)
        {
            return Json(await Service.DelMenu(menuId));
        }
        [HttpGet,HttpPost, Route("getTreeItemById")]
        [ApiActionPermission("Sys_Menu", "1", ActionPermissionOptions.Search)]
        public async Task<IActionResult> GetTreeItemByUrl(int menuId)
        {
            return JsonNormal(await _service.GetMenuItem(menuId));
        }
    }
}
