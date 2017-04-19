using System;
using System.Data.Entity;
using System.Linq;
using EntityFramework.Extensions;
using _91itsoft.Domain.Aggregates.MenuAgg;
using _91itsoft.Repository.UnitOfWork;
using PagedList;
using _91itsoft.Infrastructure.Utility.Helper;

namespace _91itsoft.Repository.Repositories
{
    public class MenuRepository : SpecificRepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(ITSoftUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public IPagedList<Menu> FindBy(string module, string name, int pageNumber, int pageSize)
        {
            IQueryable<Menu> entities = Table; 
            
            if (name.NotNullOrBlank())
            {
                entities =
                    entities.Where(x => x.Name.Contains(name));
            }

            if (module.NotNullOrBlank())
            {
                entities =
                        entities.Where(x => x.Module == module);
            }

            var totalCountQuery = entities.FutureCount();
            var resultQuery = entities
                .OrderBy(x => x.Module)
                .ThenBy(x => x.SortOrder)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Future();
            var totalCount = totalCountQuery.Value;
            var result = resultQuery.ToList();

            return new StaticPagedList<Menu>(
                result,
                pageNumber,
                pageSize,
                totalCount);
        }

        public new bool Exists(Menu item)
        {
            IQueryable<Menu> entities = Table;
            entities = entities.Where(x => x.Module == item.Module && x.Name == item.Name);
            if(item.Id != Guid.Empty)
            {
                entities = entities.Where(x => x.Id != item.Id);
            }
            return entities.Any();
        }
    }
}
