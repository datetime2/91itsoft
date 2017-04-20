using System;
using System.Collections.Generic;
using ITsoft.Application.DTOs;
using PagedList;

namespace ITsoft.Application.Services
{
    public interface IUserService
    {
        UserDTO Add(UserDTO userDTO);

        void Update(UserDTO userDTO);

        void Remove(Guid id);

        UserDTO FindBy(Guid id);

        IPagedList<UserDTO> FindBy(string name, int pageNumber, int pageSize);

        void UpdateUserPermission(Guid id, List<Guid> permissions);

        List<PermissionDTO> GetUserPermission(Guid id);

        List<IdNameDTO> GetAllUsersIdName();
    }
}
