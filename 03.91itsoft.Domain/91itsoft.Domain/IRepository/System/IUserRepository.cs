using _91itsoft.Repository;
using PagedList;
using _91itsoft.Domain.Aggregates;

namespace _91itsoft.Domain.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        IPagedList<User> FindBy(string name, int pageNumber, int pageSize);

        bool ExistsLoginName(User item);

        bool ExistsEmail(User item);
    }
}
