using System;
using System.Collections.Generic;
using ITsoft.Application.DTOs;
using PagedList;

namespace ITsoft.Application.Services
{
    public interface IAuthService
    {
        UserDTO Login(string loginName, string password, bool updateLoginToken);

        bool ValidatePassword(Guid id, string password);

        void ChangePassword(Guid id, string password);

        bool ValidateLoginToken(Guid id, string token);

        UserDTO FindByLoginToken(Guid id, string token);
        List<PermissionForAuthDTO> GetUserPermissions(Guid id);
    }
}
