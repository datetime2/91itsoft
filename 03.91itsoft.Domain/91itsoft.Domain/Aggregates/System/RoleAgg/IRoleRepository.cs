using System;
using _91itsoft.Domain.Aggregates.RoleGroupAgg;
using _91itsoft.Repository;
using PagedList;

namespace _91itsoft.Domain.Aggregates.RoleAgg
{
    public interface IRoleRepository : IRepository<Role>
    {
        IPagedList<Role> FindBy(Guid roleGroupId, string name, int pageNumber, int pageSize);
    }
}
