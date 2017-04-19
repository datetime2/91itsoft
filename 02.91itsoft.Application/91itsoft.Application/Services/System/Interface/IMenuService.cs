using System;
using System.Collections.Generic;
using _91itsoft.Application.DTOs;
using PagedList;

namespace _91itsoft.Application.Services
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
