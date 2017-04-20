using _91itsoft.Domain.Aggregates;
using _91itsoft.Repository;
using PagedList;

namespace _91itsoft.Domain.IRepository
{
    public interface IRoleGroupRepository : IRepository<RoleGroup>
    {
        IPagedList<RoleGroup> FindBy(string name, int pageNumber, int pageSize);
    }
}
