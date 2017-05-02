using System;
using System.Collections.Generic;
using ITsoft.Application.DTOs;
using PagedList;
using ITsoft.Domain.QueryModel;

namespace ITsoft.Application.Services
{
    public interface IUserService
    {
        UserDTO Add(UserDTO userDTO);

        void Update(UserDTO userDTO);

        void Remove(Guid id);

        UserDTO FindBy(Guid id);

        IPagedList<UserDTO> FindBy(UserQueryModel query);
        List<IdNameDTO> GetAllUsersIdName();
    }
}
