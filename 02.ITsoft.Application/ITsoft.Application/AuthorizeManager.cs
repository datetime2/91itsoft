﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ITsoft.Application.DTOs;
using ITsoft.Application.Services;
using ITsoft.Infrastructure.Authorize;
using ITsoft.Infrastructure.Authorize.AuthObject;
using ITsoft.Infrastructure.Utility.Extensions;
using ITsoft.Infrastructure.Utility.Helper;
using ITsoft.Plugin.Cache;
namespace ITsoft.Application.Managers
{
    public class AuthorizeManager : IAuthorizeManager
    {
        private static ConcurrentDictionary<string, string> CacheKeys = new ConcurrentDictionary<string, string>();
        private IAuthService AuthService { get; set; }
        public AuthorizeManager(IAuthService authService)
        {
            AuthService = authService;
        }
        #region Private Methods
        private static string GetTokenKey(string token)
        {
            return string.Format("AUTH_TOKEN_{0}", token);
        }
        private void RegisterToken(string token, string user = "SoftUser", bool rememberMe = false)
        {
            if (token.IsNullOrBlank())
                throw new ArgumentNullException("token", token);
            DateTime expiration = rememberMe ? DateTime.Now.AddDays(7) : DateTime.Now.Add(FormsAuthentication.Timeout);
            var ticket = new FormsAuthenticationTicket(1, user, DateTime.Now, expiration, true, token, FormsAuthentication.FormsCookiePath);
            string hashTicket = FormsAuthentication.Encrypt(ticket);
            var userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket) { Domain = FormsAuthentication.CookieDomain };
            if (rememberMe)
                userCookie.Expires = expiration;
            HttpContext.Current.Response.Cookies.Set(userCookie);
        }
        private void RemoveToken(string token)
        {
            Cache.Remove(GetTokenKey(token));
        }
        private void SetCacheAuthUser(string authToken, UserForAuthorize authUser)
        {
            var key = GetTokenKey(authToken);
            // 缓存起来
            Cache.Set(key, authUser, 12 * 60);
            CacheKeys.TryAdd(key, key);
        }
        private UserForAuthorize GetAuthorizeUserInfo(string token, bool validateLoginToken = true)
        {
            var authUser = Cache.Get<UserForAuthorize>(GetTokenKey(token));
            var datas = token.Split('_');
            var loginToken = string.Empty;
            if (datas.Length == 2)
            {
                var userId = Guid.Parse(datas[0]);
                loginToken = datas[1];
                if (authUser == null)
                {
                    // 尝试从数据库读取
                    var user = AuthService.FindByLoginToken(userId, loginToken);
                    if (user != null)
                    {
                        authUser = GetAuthUserFromDb(user);
                        // 写入到缓存
                        SetCacheAuthUser(token, authUser);
                    }
                }
            }
            if (validateLoginToken)
                if (authUser == null || !AuthService.ValidateLoginToken(authUser.UserId, loginToken))
                    return null;
            return authUser;
        }

        private UserForAuthorize GetAuthUserFromDb(UserDTO user)
        {
            var authUser = new UserForAuthorize()
            {
                LoginName = user.LoginName,
                UserId = user.Id,
                UserName = user.Name
            };
            // 权限和菜单信息
            var menus = AuthService.GetUserMenus(user.Id);
            //按钮

            //菜单
            authUser.Menus = menus.Where(s => s.ParentId.Equals(Guid.Empty)).Select(x => new MenuForAuthorize()
            {
                MenuId = x.Id,
                ParentId = x.ParentId,
                MenuName = x.Name,
                MenuUrl = x.Url,
                MenuIcon = x.Icon,
                MenuCode = x.Code,
                SortOrder = x.SortOrder,
                Childs = menus.Where(ss => ss.ParentId.Equals(x.Id)).Select(xx => new MenuForAuthorize
                {
                    MenuId = xx.Id,
                    ParentId = xx.ParentId,
                    MenuName = xx.Name,
                    MenuUrl = xx.Url,
                    MenuIcon = xx.Icon,
                    MenuCode = xx.Code,
                    SortOrder = xx.SortOrder
                }).ToList()
            }).OrderBy(x => x.SortOrder).ToList();
            return authUser;
        }
        #endregion

        public string GetCurrentTokenFromCookies()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var token = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket.UserData;
                if (token.NotNullOrBlank())
                    return token;
                throw new AuthorizeTokenNotFoundException();
            }
            throw new AuthorizeTokenNotFoundException();
        }

        public UserForAuthorize GetCurrentUserInfo()
        {
            var token = this.GetCurrentTokenFromCookies();
            return GetAuthorizeUserInfo(token);
        }

        public UserForAuthorize GetAuthorizeUserInfo(UserToken user)
        {
            var token = user.GetAuthToken();
            return GetAuthorizeUserInfo(token, false);
        }

        public void ClearCache()
        {
            foreach (var cacheKey in CacheKeys)
            {
                Cache.Remove(cacheKey.Key);
            }
        }

        public void SignIn(string loginName, string password, bool rememberMe = false)
        {
            var user = AuthService.Login(loginName, password, true);
            var authUser = GetAuthUserFromDb(user);
            var dataToken = new UserToken() {UserId = user.Id, LastLoginToken = user.LastLoginToken}.GetAuthToken();
            // Cache
            SetCacheAuthUser(dataToken, authUser);
            // Cookies
            RegisterToken(dataToken, authUser.UserName, rememberMe);
        }

        public void SignOut()
        {
            try
            {
                var token = this.GetCurrentTokenFromCookies();
                RemoveToken(token);
                FormsAuthentication.SignOut();
            }
            catch (AuthorizeTokenNotFoundException)
            {
                return;
            }
        }

        public void RedirectToLoginPage()
        {
            FormsAuthentication.RedirectToLoginPage();
        }

        public bool ValidatePermission(string code, bool throwExceptionIfNotPass = true)
        {
            var user = GetCurrentUserInfo();
            if (user == null)
                throw new AuthorizeTokenInvalidException();
            var permission = user.Menus.FirstOrDefault(x => x.MenuCode.Equals(code));
            if (permission == null && throwExceptionIfNotPass)
                throw new AuthorizeNoPermissionException();
            return permission != null;
        }
    }
}
