using System;
using _91itsoft.Repository;
using PagedList;

namespace _91itsoft.Domain.Aggregates.UserAgg
{
    public interface IUserRepository : IRepository<User>
    {
        IPagedList<User> FindBy(string name, int pageNumber, int pageSize);

        bool ExistsLoginName(User item);

        bool ExistsEmail(User item);
    }
}
