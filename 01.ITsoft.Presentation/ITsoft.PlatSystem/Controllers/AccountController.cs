using ITsoft.Application.Exceptions;
using ITsoft.Infrastructure.Authorize;
using ITsoft.Infrastructure.Utility.Extensions;
using ITsoft.Infrastructure.Utility.Helper;
using ITsoft.PlatSystem.Models;
using System;
using System.Web.Mvc;
namespace ITsoft.PlatSystem.Controllers
{
    public class AccountController : BaseController
    {
        IAuthorizeManager AuthorizeManager;
        public AccountController(IAuthorizeManager authorizeManager)
        {
            AuthorizeManager = authorizeManager;
        }
        public ActionResult Login()
        {
            var returnUrl = Request["ReturnUrl"] ?? "/";
            if (returnUrl.IndexOf("Logout", StringComparison.OrdinalIgnoreCase) > -1)
                returnUrl = "/";
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string returnUrl, string loginName, string password, bool? rememberMe)
        {
            var response = new AjaxResponse();
            try
            {
                AuthorizeManager.SignIn(loginName, password, rememberMe.HasValue && rememberMe.Value);
                response.Succeeded = true;
                response.RedirectUrl = returnUrl;
            }
            catch (Exception ex)
            {
                if (!(ex is DefinedException))
                {
                    Log.Error(ex.GetIndentedExceptionLog());
                }
                response.Succeeded = false;
                response.ErrorMessage = ex.Message;
                response.ShowMessage = true;
            }
            return Json(response);
        }
    }
}