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
        [HttpPost]
        public ActionResult submitForm(Role roleEntity, string menus, string keyValue)
        {
            //_roleServiceApp.UpdateRoleMenu()
            //roleApp.SubmitForm(roleEntity, permissionIds.Split(','), keyValue);
            return Success("操作成功");
        }
        [HttpGet]
        public JsonResult roleAuthorize(Guid roleId)
        {
            var grid = _roleServiceApp.RoleModuleTree(roleId);
            return Json(grid, JsonRequestBehavior.AllowGet);
        }
    }
}