using System;
using System.Collections.Generic;
using ITsoft.Application.DTOs;
using PagedList;
using ITsoft.Domain.QueryModel;
using System.Linq.Expressions;
using ITsoft.Domain.Aggregates;

namespace ITsoft.Application.Services
{
    public interface IMenuService
    {
        MenuDTO Add(MenuDTO menuDTO);
        void Update(MenuDTO menuDTO);
        void Remove(Guid id);
        MenuDTO FindBy(Guid id);
        IPagedList<MenuDTO> FindBy(MenuQueryModel query);
        List<MenuDTO> FindBy(Expression<Func<Menu, bool>> query);
    }
}
