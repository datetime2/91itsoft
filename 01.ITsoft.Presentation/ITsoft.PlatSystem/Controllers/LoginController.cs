using ITsoft.Application.Exceptions;
using ITsoft.Infrastructure.Authorize;
using ITsoft.Infrastructure.Utility.Extensions;
using ITsoft.Infrastructure.Utility.Helper;
using ITsoft.PlatSystem.Models;
using System;
using System.Web.Mvc;
namespace ITsoft.PlatSystem.Controllers
{
    public class LoginController : BaseController
    {
        IAuthorizeManager AuthorizeManager;
        public LoginController(IAuthorizeManager authorizeManager)
        {
            AuthorizeManager = authorizeManager;
        }
        public ActionResult Logout()
        {
            AuthorizeManager.SignOut();
            AuthorizeManager.RedirectToLoginPage();
            return null;
        }
        [HttpPost]
        public ActionResult SignIn(string ReturnUrl, string LoginName, string PassWord, string Code,bool? rememberMe=true)
        {
            var response = new AjaxResponse();
            try
            {
                AuthorizeManager.SignIn(LoginName, PassWord, rememberMe.Value);
                response.Succeeded = true;
                response.RedirectUrl = "";
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
        [HttpGet]
        public ActionResult AuthCode()
        {
            string code;
            var file = VerifyCode.GetVerifyCode(out code);
            Session["checkCode"] = code;
            return File(file, @"image/Gif");
        }
    }
}