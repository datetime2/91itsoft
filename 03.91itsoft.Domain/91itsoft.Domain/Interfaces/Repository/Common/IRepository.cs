using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _91itsoft.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity>
      where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}