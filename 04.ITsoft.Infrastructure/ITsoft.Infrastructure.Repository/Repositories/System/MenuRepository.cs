using System;
using System.Data.Entity;
using System.Linq;
using EntityFramework.Extensions;
using ITsoft.Domain.Aggregates;
using ITsoft.Repository.UnitOfWork;
using PagedList;
using ITsoft.Infrastructure.Utility.Helper;
using ITsoft.Domain.IRepository;
using ITsoft.Domain.QueryModel;

namespace ITsoft.Repository.Repositories
{
    public class MenuRepository : SpecificRepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(ITSoftUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public IPagedList<Menu> FindBy(MenuQueryModel query)
        {
            IQueryable<Menu> entities = Table;
            if (query.Name.NotNullOrBlank())
            {
                entities =
                    entities.Where(x => x.Name.Contains(query.Name));
            }
            var totalCountQuery = entities.FutureCount();
            var resultQuery = entities
                .OrderBy(x => x.SortOrder)
                .Skip((query.page.Value - 1) * query.rows.Value)
                .Take(query.rows.Value)
                .Future();
            var totalCount = totalCountQuery.Value;
            var result = resultQuery.ToList();
            return new StaticPagedList<Menu>(
                result,
                query.page.Value,
                query.rows.Value,
                totalCount);
        }

        public new bool Exists(Menu item)
        {
            IQueryable<Menu> entities = Table;
            entities = entities.Where(x => x.Name == item.Name);
            if (item.Id != Guid.Empty)
            {
                entities = entities.Where(x => x.Id != item.Id);
            }
            return entities.Any();
        }
    }
}
