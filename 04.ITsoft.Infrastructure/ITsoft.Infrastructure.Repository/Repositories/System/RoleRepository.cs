using System;
using System.Data.Entity;
using System.Linq;
using EntityFramework.Extensions;
using ITsoft.Infrastructure.Utility.Helper;
using ITsoft.Repository.UnitOfWork;
using PagedList;
using ITsoft.Domain.Aggregates;
using ITsoft.Domain.IRepository;
using ITsoft.Domain.QueryModel;
using System.Collections.Generic;

namespace ITsoft.Repository.Repositories
{
    public class RoleRepository : SpecificRepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ITSoftUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IPagedList<Role> FindBy(RoleQueryModel query)
        {
            IQueryable<Role> entities = Table;
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
            return new StaticPagedList<Role>(
                result,
                query.page.Value,
                query.rows.Value,
                totalCount);
        }

        public new bool Exists(Role item)
        {
            IQueryable<Role> entities = Table;
            entities = entities.Where(x => x.Name == item.Name);
            if (item.Id != Guid.Empty)
                entities = entities.Where(x => x.Id != item.Id);
            return entities.Any();
        }

        public IEnumerable<Menu> RoleMenu(Guid roleId)
        {
            IQueryable<Role> entities = Table;
            return entities.FirstOrDefault(s => s.Id == roleId).Menus;
        }
    }
}
