using System;
using System.Collections.Generic;
using ITsoft.Application.DTOs;
using PagedList;
using ITsoft.Domain.QueryModel;
using ITsoft.Domain.ViewModel;

namespace ITsoft.Application.Services
{
    public interface IRoleService
    {
        RoleDTO Add(RoleDTO roleDTO);
        void Update(RoleDTO roleDTO);
        void Remove(Guid id);
        List<RoleDTO> FindAll();
        RoleDTO FindBy(Guid id);
        IPagedList<RoleDTO> FindBy(RoleQueryModel query);
        void UpdateRoleMenu(Guid id, List<Guid> menus);
        List<MenuDTO> GetRoleMenu(Guid id);
        List<TreeViewModel> RoleModuleTree(Guid roleId);
    }
}
