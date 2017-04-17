using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using _91itsoft.Domain.Interfaces.Repository;
using _91itsoft.Domain.Interfaces.Service;

namespace _91itsoft.Domain.Services.Common
{
    public class Service<TEntity> : IService<TEntity>
        where TEntity : class
    {
        #region Constructor
        private readonly IRepository<TEntity> _repository;
        public Service(
            IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods

        public virtual TEntity Get(int id)
        {
            return _repository.Get(id);
        }
        public virtual IEnumerable<TEntity> All()
        {
            return _repository.All();
        }
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Find(predicate);
        }
        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }
        #endregion
    }
}
