using System;
using System.Collections.Generic;
using ITsoft.Application.DTOs;
using PagedList;

namespace ITsoft.Application.Services
{
    public interface IRoleGroupService
    {
        RoleGroupDTO Add(RoleGroupDTO roleGroupDTO);

        void Update(RoleGroupDTO roleGroupDTO);

        void Remove(Guid id);

        List<RoleGroupDTO> FindAll();

        RoleGroupDTO FindBy(Guid id);

        IPagedList<RoleGroupDTO> FindBy(string name, int pageNumber, int pageSize);

        List<IdNameDTO> GetUsersIdName(Guid groupId);

        void UpdateGroupUsers(Guid id, List<Guid> users);
    }
}
