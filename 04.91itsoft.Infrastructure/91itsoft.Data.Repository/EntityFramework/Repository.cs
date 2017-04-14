using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.ServiceLocation;
using _91itsoft.Data.Context.Interfaces;
using _91itsoft.Domain.Interfaces.Repository.Common;
using _91itsoft.Data.Context;

namespace _91itsoft.Data.Repository.EntityFramework.Common
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly IDbContext _dbContext;
        private readonly IDbSet<TEntity> _dbSet;
        public Repository()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager<ItSoftStoreContext>>() 
                as ContextManager<ItSoftStoreContext>;
            _dbContext = contextManager.GetContext();
            _dbSet = _dbContext.Set<TEntity>();
        }

        protected IDbContext Context
        {
            get { return _dbContext; }
        }

        protected IDbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> All()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return  DbSet.Where(predicate);
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }

        #endregion
    }
}
