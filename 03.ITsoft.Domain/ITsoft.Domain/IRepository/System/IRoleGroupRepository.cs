using ITsoft.Domain.Aggregates;
using ITsoft.Repository;
using PagedList;

namespace ITsoft.Domain.IRepository
{
    public interface IRoleGroupRepository : IRepository<RoleGroup>
    {
        IPagedList<RoleGroup> FindBy(string name, int pageNumber, int pageSize);
    }
}
