using _91itsoft.Domain.Aggregates;
using _91itsoft.Repository;
using PagedList;
using System;

namespace _91itsoft.Domain.IRepository
{
    public interface IRoleRepository : IRepository<Role>
    {
        IPagedList<Role> FindBy(Guid roleGroupId, string name, int pageNumber, int pageSize);
    }
}
