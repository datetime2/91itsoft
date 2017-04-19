﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _91itsoft.UnitOfWork;

namespace _91itsoft.Repository.UnitOfWork
{
    public interface ITSoftUnitOfWork : IUnitOfWork
    {
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;

        DbContext DbContext { get; }
    }
}
