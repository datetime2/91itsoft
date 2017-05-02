using ITsoft.Application.Services;
using System.Web.Mvc;

namespace ITsoft.PlatSystem.Controllers
{
    public class HomeController : BaseAuthorizeController
    {
        IMenuService _menuService;
        public HomeController(IMenuService menuService)
        {
            this._menuService = menuService;
        }
        public ActionResult Main()
        {
            return View();
        }
        [HttpGet]
        public JsonResult Permission()
        {
            var menus = _menuService.FindByModule("系统");
            return Json(menus, JsonRequestBehavior.AllowGet);
        }
    }
}