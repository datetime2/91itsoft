using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _91itsoft.Domain.Interfaces.Service.Common
{
    public interface IService<TEntity>
        where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}