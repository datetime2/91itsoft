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

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}