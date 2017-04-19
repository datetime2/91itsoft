﻿using System;
using System.Collections.Generic;
using _91itsoft.Application.DTOs;
using PagedList;

namespace _91itsoft.Application.Services
{
    public interface IRoleService
    {
        RoleDTO Add(RoleDTO roleDTO);

        void Update(RoleDTO roleDTO);

        void Remove(Guid id);

        List<RoleDTO> FindAll();

        RoleDTO FindBy(Guid id);

        IPagedList<RoleDTO> FindBy(Guid roleGroupId, string name, int pageNumber, int pageSize);

        void UpdateRolePermission(Guid id, List<Guid> permissions);

        List<PermissionDTO> GetRolePermission(Guid id);
    }
}