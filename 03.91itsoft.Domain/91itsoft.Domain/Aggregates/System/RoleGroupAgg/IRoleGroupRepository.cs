using _91itsoft.Repository;
using PagedList;

namespace _91itsoft.Domain.Aggregates.RoleGroupAgg
{
    public interface IRoleGroupRepository : IRepository<RoleGroup>
    {
        IPagedList<RoleGroup> FindBy(string name, int pageNumber, int pageSize);
    }
}
