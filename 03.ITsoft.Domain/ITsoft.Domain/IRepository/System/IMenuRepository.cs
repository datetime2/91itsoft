using ITsoft.Domain.Aggregates;
using ITsoft.Domain.QueryModel;
using ITsoft.Repository;
using PagedList;
namespace ITsoft.Domain.IRepository
{
    public interface IMenuRepository : IRepository<Menu>
    {
        IPagedList<Menu> FindBy(MenuQueryModel query);
    }
}
