using ITsoft.Application.Services;
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
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }
        /// <summary>
        /// 列表加载
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult InitGrid(RoleQueryModel query)
        {
            var grid = _roleService.FindBy(query);
            return Json(new
            {
                rows=grid[0],
                page=query.page,
                size=query.rows,
                records=grid.GetMetaData().TotalItemCount,
                total= grid.GetMetaData().PageCount
            }, JsonRequestBehavior.AllowGet);
        }
    }
}