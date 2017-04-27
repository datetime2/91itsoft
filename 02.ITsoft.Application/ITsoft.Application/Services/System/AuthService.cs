using System;
using System.Collections.Generic;
using System.Linq;
using ITsoft.Application.Exceptions;
using ITsoft.Application.Resources;
using ITsoft.Application.AutoMappers;
using ITsoft.Application.DTOs;
using ITsoft.Infrastructure.Utility;
using ITsoft.Infrastructure.Utility.Helper;
using ITsoft.Application.SystemModules;
using ITsoft.Domain.IRepository;

namespace ITsoft.Application.Services
{
    public class AuthService : IAuthService
    {
        #region 私有成员
        IUserRepository _UserRepository;
        private void UpdateLoginToken(Guid id, string loginToken, DateTime lastLoginTime)
        {
            var user = _UserRepository.Get(id);
            if (user == null)
                throw new ArgumentException(id.ToString(), "id");
            user.LastLoginToken = loginToken;
            user.LastLogin = lastLoginTime;
            //commit unit of work
            _UserRepository.UnitOfWork.Commit();
        }

        #endregion

        #region Constructors

        public AuthService(IUserRepository userRepository)                               
        {
            if (userRepository == null)
                throw new ArgumentNullException("userRepository");
            _UserRepository = userRepository;
        }

        #endregion

        public UserDTO Login(string loginName, string password, bool updateLoginToken)
        {
            if (loginName.IsNullOrBlank())
                throw new ArgumentEmptyException(UserSystemResource.Login_NameEmpty);
            if (password.IsNullOrBlank())
                throw new ArgumentEmptyException(UserSystemResource.Login_PasswordEmpty);
            var user = _UserRepository.Find(x => x.LoginName.Equals(loginName));
            if (user == null)
                throw new NotFoundException(UserSystemResource.Login_NameNotFound);
            if (!EncryptPassword(password,user.PwdSalt,true).EqualsIgnoreCase(user.LoginPwd))
                throw new NotEqualException(UserSystemResource.Login_PasswordIncorrect);
            if (updateLoginToken)
            {
                var newToken = SecurityHelper.NetxtString(24).ToLower();
                UpdateLoginToken(user.Id, newToken, DateTime.UtcNow);
                user.LastLoginToken = newToken;
            }
            if (user.LastLoginToken.IsNullOrBlank())
                throw new ArgumentEmptyException(UserSystemResource.Login_TokenEmpty);
            return user.ToDto();
        }

        public bool ValidatePassword(Guid id, string password)
        {
            var user = _UserRepository.Get(id);
            if (user == null)
                throw new ArgumentException(id.ToString(), "id");
            return EncryptPassword(password,user.PwdSalt,true).EqualsIgnoreCase(user.LoginPwd);
        }

        public void ChangePassword(Guid id, string password)
        {
            var user = _UserRepository.Get(id);
            if (user == null)
                throw new ArgumentException(id.ToString(), "id");
            user.LoginPwd = EncryptPassword(password, user.PwdSalt, true);
            //commit unit of work
            _UserRepository.UnitOfWork.Commit();
        }

        public bool ValidateLoginToken(Guid id, string token)
        {
            if (token.IsNullOrBlank())
                throw new ArgumentException(token, "token");
            var user = _UserRepository.Get(id);
            if (user == null)
                throw new ArgumentException(id.ToString(), "id");
            return token.EqualsIgnoreCase(user.LastLoginToken);
        }

        public UserDTO FindByLoginToken(Guid id, string token)
        {
            var user = _UserRepository.Get(id);
            if (user == null)
                throw new ArgumentException(id.ToString(), "id");
            user.LastLoginToken = user.LastLoginToken ?? string.Empty;
            if (!user.LastLoginToken.EqualsIgnoreCase(token))
                throw new DataNotFoundException(UserSystemResource.User_NotExists);
            return user.ToDto();
        }

        public List<PermissionForAuthDTO> GetUserPermissions(Guid id)
        {
            var user = _UserRepository.Get(id);
            if (user == null)
                throw new ArgumentException(id.ToString(), "id");
            var permissions = new List<PermissionForAuthDTO>();
            foreach (var role in user.Roles.Where(role => role.Permissions != null))
            {
                permissions.AddRange(role.Permissions.Select(x => new PermissionForAuthDTO()
                {
                    PermissionId = x.Id,
                    PermissionCode = x.Code,
                    MenuId = x.Menu.Id,
                    RoleId = role.Id,
                    PermissionName = x.Name,
                    MenuName = x.Menu.Name,
                    MenuUrl = x.Menu.Url,
                    RoleName = role.Name,
                    PermissionSortOrder = x.SortOrder,
                    MenuSortOrder = x.Menu.SortOrder,
                    Module = (ModuleType)Enum.Parse(typeof(ModuleType), x.Menu.Module),
                    ModuleName = ModulesManager.Instance.GetModulesName(x.Menu.Module)
                }));
            }
            return permissions;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passsalt"></param>
        /// <param name="isMD5">是否传递的MD5后的密码</param>
        /// <returns></returns>
        public static string EncryptPassword(string password, string passsalt, bool? isMD5 = false)
        {
            if (!isMD5.Value)
                return SecurityHelper.Md5(SecurityHelper.Md5(password) + passsalt);
            else
                return SecurityHelper.Md5(password + passsalt);
        }
    }
}
