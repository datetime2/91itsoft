using ITsoft.Application.Services;
using System.Web.Mvc;

namespace ITsoft.PlatSystem.Controllers
{
    public class HomeController : BaseAuthorizeController
    {
        public ActionResult Main()
        {
            return View();
        }
        [HttpGet]
        public JsonResult Permission()
        {
            return Json(GetCurrentUser().Menus, JsonRequestBehavior.AllowGet);
        }
    }
}