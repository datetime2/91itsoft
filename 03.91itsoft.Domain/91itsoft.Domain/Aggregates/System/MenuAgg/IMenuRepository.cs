using _91itsoft.Repository;
using PagedList;
namespace _91itsoft.Domain.Aggregates.MenuAgg
{
    public interface IMenuRepository : IRepository<Menu>
    {
        IPagedList<Menu> FindBy(string module, string name, int pageNumber, int pageSize);
    }
}
