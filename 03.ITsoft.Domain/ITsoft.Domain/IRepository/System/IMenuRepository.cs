using ITsoft.Domain.Aggregates;
using ITsoft.Repository;
using PagedList;
namespace ITsoft.Domain.IRepository
{
    public interface IMenuRepository : IRepository<Menu>
    {
        IPagedList<Menu> FindBy(string module, string name, int pageNumber, int pageSize);
    }
}
