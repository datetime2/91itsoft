using System;
using System.Linq;
using _91itsoft.Domain.Aggregates.MenuAgg;
using _91itsoft.Repository.UnitOfWork;

namespace _91itsoft.Repository.Repositories
{
    public class PermissionRepository : SpecificRepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(ITSoftUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public new bool Exists(Permission item)
        {
            IQueryable<Permission> entities = Table;
            entities = entities.Where(x => x.Menu == item.Menu && x.Name == item.Name);
            if(item.Id != Guid.Empty)
            {
                entities = entities.Where(x => x.Id != item.Id);
            }
            return entities.Any();
        }
    }
}
