using System;
using System.Data.Entity;
using System.Linq;
using EntityFramework.Extensions;
using _91itsoft.Domain.Aggregates.RoleAgg;
using _91itsoft.Domain.Aggregates.RoleGroupAgg;
using _91itsoft.Utility.Helper;
using _91itsoft.Repository.UnitOfWork;
using PagedList;

namespace _91itsoft.Repository.Repositories
{
    public class RoleGroupRepository : SpecificRepositoryBase<RoleGroup>, IRoleGroupRepository
    {
        public RoleGroupRepository(ITSoftUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IPagedList<RoleGroup> FindBy(string name, int pageNumber, int pageSize)
        {
            IQueryable<RoleGroup> entities = Table; 
            
            if (name.NotNullOrBlank())
            {
                entities =
                    entities.Where(x => x.Name.Contains(name));
            }

            var totalCountQuery = entities.FutureCount();
            var resultQuery = entities
                .OrderBy(x => x.SortOrder)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Future();

            var totalCount = totalCountQuery.Value;
            var result = resultQuery.ToList();

            return new StaticPagedList<RoleGroup>(
                result,
                pageNumber,
                pageSize,
                totalCount);
        }

        public new bool Exists(RoleGroup item)
        {
            IQueryable<RoleGroup> entities = Table;
            entities = entities.Where(x => x.Name == item.Name);
            if (item.Id != Guid.Empty)
            {
                entities = entities.Where(x => x.Id != item.Id);
            }
            return entities.Any();
        }
    }
}
