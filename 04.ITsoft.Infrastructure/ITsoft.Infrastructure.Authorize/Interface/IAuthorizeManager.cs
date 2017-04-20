using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITsoft.Infrastructure.Authorize.AuthObject;

namespace ITsoft.Infrastructure.Authorize
{
    public interface IAuthorizeManager
    {
        string GetCurrentTokenFromCookies();
        UserForAuthorize GetCurrentUserInfo();
        void SignIn(string loginName, string password, bool rememberMe = false);
        void SignOut();
        void RedirectToLoginPage();
        bool ValidatePermission(string permissionCode, bool throwExceptionIfNotPass = true);
        UserForAuthorize GetAuthorizeUserInfo(UserToken user);
        void ClearCache();
    }
}
