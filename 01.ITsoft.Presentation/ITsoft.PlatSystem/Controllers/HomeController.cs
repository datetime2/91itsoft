using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITsoft.PlatSystem.Controllers
{
    public class HomeController : BaseAuthorizeController
    {
        public ActionResult Main()
        {
            return View();
        }
    }
}