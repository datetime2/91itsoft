using System;
using System.Linq;
using ITsoft.Domain.Aggregates;
using ITsoft.Repository.UnitOfWork;
using ITsoft.Domain.IRepository;

namespace ITsoft.Repository.Repositories
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
