﻿using ITsoft.Domain.Aggregates;
using ITsoft.Repository;
using PagedList;
using System;

namespace ITsoft.Domain.IRepository
{
    public interface IRoleRepository : IRepository<Role>
    {
        IPagedList<Role> FindBy(string name, int pageNumber, int pageSize);
    }
}
