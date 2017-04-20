using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITsoft.PlatSystem.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public virtual ActionResult Index()
        {
            return View();
        }
        public virtual ActionResult List()
        {
            return View();
        }
    }
}