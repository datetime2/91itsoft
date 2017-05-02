using System;
using System.Data.Entity;
using System.Linq;
using EntityFramework.Extensions;
using ITsoft.Infrastructure.Utility.Helper;
using ITsoft.Repository.UnitOfWork;
using PagedList;
using ITsoft.Domain.IRepository;
using ITsoft.Domain.Aggregates;
using ITsoft.Domain.QueryModel;

namespace ITsoft.Repository.Repositories
{
    public class UserRepository : SpecificRepositoryBase<User>, IUserRepository
    {
        public UserRepository(ITSoftUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IPagedList<User> FindBy(UserQueryModel query)
        {
            IQueryable<User> entities = Table;

            if (query.Name.NotNullOrBlank())
            {
                entities =
                    entities.Where(x => x.Name.Contains(query.Name));
            }

            var totalCountQuery = entities.FutureCount();
            var resultQuery = entities
                .OrderByDescending(x => x.Created)
                .Skip((query.page.Value - 1) * query.rows.Value)
                .Take(query.rows.Value)
                .Future();

            var totalCount = totalCountQuery.Value;
            var result = resultQuery.ToList();

            return new StaticPagedList<User>(
                result,
                query.page.Value,
                query.rows.Value,
                totalCount);
        }

        public bool ExistsLoginName(User item)
        {
            IQueryable<User> entities = Table;
            entities = entities.Where(x => x.LoginName == item.LoginName);
            if (item.Id != Guid.Empty)
            {
                entities = entities.Where(x => x.Id != item.Id);
            }
            return entities.Any();
        }

        public bool ExistsEmail(User item)
        {
            IQueryable<User> entities = Table;
            entities = entities.Where(x => x.Email == item.Email);
            if (item.Id != Guid.Empty)
            {
                entities = entities.Where(x => x.Id != item.Id);
            }
            return entities.Any();
        }

        public new bool Exists(User item)
        {
            IQueryable<User> entities = Table;
            entities = entities.Where(x => x.Name == item.Name);
            if (item.Id != Guid.Empty)
            {
                entities = entities.Where(x => x.Id != item.Id);
            }
            return entities.Any();
        }
    }
}
