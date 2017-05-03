using ITsoft.PlatSystem.Models;
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
        public virtual ActionResult Form()
        {
            return View();
        }
        public virtual ActionResult List()
        {
            return View();
        }

        protected virtual JsonResult Success(string message)
        {
            return Json(new AjaxResponse { Succeeded = true, State = ResultType.success.ToString(), Message = message });
        }
        protected virtual JsonResult Error(string message)
        {
            return Json(new AjaxResponse { Succeeded = false, State = ResultType.error.ToString(), Message = message });
        }
    }
}