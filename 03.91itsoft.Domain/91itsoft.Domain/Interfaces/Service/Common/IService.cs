using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _91itsoft.Domain.Interfaces.Service
{
    public interface IService<TEntity>
        where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}