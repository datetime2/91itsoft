using ITsoft.Repository;
using PagedList;
using ITsoft.Domain.Aggregates;

namespace ITsoft.Domain.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        IPagedList<User> FindBy(string name, int pageNumber, int pageSize);

        bool ExistsLoginName(User item);

        bool ExistsEmail(User item);
    }
}
