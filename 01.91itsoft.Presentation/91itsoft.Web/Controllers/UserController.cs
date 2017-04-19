using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _91itsoft.Web.Controllers
{
    public class UserController : BaseAuthorizeController
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}