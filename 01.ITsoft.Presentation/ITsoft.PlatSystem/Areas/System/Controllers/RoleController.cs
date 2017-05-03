using ITsoft.Application.DTOs;
using ITsoft.Application.Services;
using ITsoft.Domain.Aggregates;
using ITsoft.Domain.QueryModel;
using ITsoft.PlatSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITsoft.PlatSystem.Areas.System.Controllers
{
    public class RoleController : BaseAuthorizeController
    {
        private readonly IRoleService _roleServiceApp;
        private readonly IMenuService _menuServiceApp;
        public RoleController(IRoleService roleService, IMenuService menuService)
        {
            this._roleServiceApp = roleService;
            this._menuServiceApp = menuService;
        }
        /// <summary>
        /// 列表加载
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult InitGrid(RoleQueryModel query)
        {
            var grid = _roleServiceApp.FindBy(query);
            return Json(new
            {
                rows = grid,
                total = grid.GetMetaData().PageCount,
                page = query.page,
                records = grid.GetMetaData().TotalItemCount
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Form加载
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult initForm(Guid keyValue)
        {
            var data = _roleServiceApp.FindBy(keyValue);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 角色修改(权限修改)
        /// </summary>
        /// <param name="roleEntity"></param>
        /// <param name="menuIds"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult submitForm(RoleDTO roleEntity, string menuIds,Guid? keyValue)
        {
            roleEntity.Id = keyValue.HasValue ? keyValue.Value : Guid.Empty;
            _roleServiceApp.UpdateRoleMenu(roleEntity, menuIds.Split(',').Select(s => Guid.Parse(s)));
            return Success("操作成功");
        }
        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult roleAuthorize(Guid? roleId)
        {
            var grid = _roleServiceApp.RoleModuleTree(roleId.HasValue ? roleId.Value : Guid.Empty);
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult deleteForm(Guid keyValue)
        {
            _roleServiceApp.Remove(keyValue);
            return Success("操作成功");
        }
    }
}