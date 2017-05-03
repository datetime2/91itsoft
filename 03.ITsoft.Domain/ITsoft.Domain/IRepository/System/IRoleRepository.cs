using ITsoft.Domain.Aggregates;
using ITsoft.Domain.QueryModel;
using ITsoft.Repository;
using PagedList;
using System;
using System.Collections.Generic;

namespace ITsoft.Domain.IRepository
{
    public interface IRoleRepository : IRepository<Role>
    {
        IPagedList<Role> FindBy(RoleQueryModel query);
        IEnumerable<Menu> RoleMenu(Guid roleId);
    }
}
