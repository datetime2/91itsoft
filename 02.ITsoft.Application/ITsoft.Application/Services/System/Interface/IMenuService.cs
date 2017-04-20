using System;
using System.Collections.Generic;
using ITsoft.Application.DTOs;
using PagedList;

namespace ITsoft.Application.Services
{
    public interface IMenuService
    {
        MenuDTO Add(MenuDTO menuDTO);

        void Update(MenuDTO menuDTO);

        void Remove(Guid id);

        void UpdatePermission(MenuDTO menuDTO);

        MenuDTO FindBy(Guid id);

        IPagedList<MenuDTO> FindBy(string module, string name, int pageNumber, int pageSize);

        List<MenuDTO> FindByModule(string module);
    }
}
