using ITsoft.Repository;
using PagedList;
using ITsoft.Domain.Aggregates;
using ITsoft.Domain.QueryModel;

namespace ITsoft.Domain.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        IPagedList<User> FindBy(UserQueryModel query);

        bool ExistsLoginName(User item);

        bool ExistsEmail(User item);
    }
}
