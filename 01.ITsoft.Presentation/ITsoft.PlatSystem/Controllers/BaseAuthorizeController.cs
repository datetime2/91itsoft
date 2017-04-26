using ITsoft.Infrastructure.Authorize;
using ITsoft.Infrastructure.Authorize.AuthObject;
using ITsoft.PlatSystem.Helper;
using System.Web.Mvc;

namespace ITsoft.PlatSystem.Controllers
{
    public class BaseAuthorizeController : BaseController
    {
        private ServiceResolver _serviceResolver;
        private UserForAuthorize _CurrentUser;
        public BaseAuthorizeController()
        {
            ViewBag.CurrentUser = GetCurrentUser();
        }
        public ServiceResolver ServiceResolver
        {
            get { return _serviceResolver ?? (_serviceResolver = new ServiceResolver()); }
        }
        private IAuthorizeManager AuthorizeManager
        {
            get
            {
                return ServiceResolver.Resolve<IAuthorizeManager>();
            }
        }
        protected UserForAuthorize GetCurrentUser()
        {
            try
            {
                _CurrentUser = AuthorizeManager.GetCurrentUserInfo();
            }
            catch (AuthorizeTokenNotFoundException)
            {
            }
            return _CurrentUser;
        }
        protected virtual void CheckLogin()
        {
            if (GetCurrentUser() == null)
                AuthorizeManager.RedirectToLoginPage();
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            CheckLogin();
        }
    }
}