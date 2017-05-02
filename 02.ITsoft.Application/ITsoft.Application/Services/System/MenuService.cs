using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ITsoft.Application.Exceptions;
using ITsoft.Application.Resources;
using ITsoft.Application.AutoMappers;
using ITsoft.Application.DTOs;
using ITsoft.Entity;
using ITsoft.Infrastructure.Utility.Helper;
using PagedList;
using ITsoft.Domain.IRepository;
using ITsoft.Domain.Aggregates;
using ITsoft.Domain.QueryModel;
using System.Linq.Expressions;

namespace ITsoft.Application.Services
{
    public class MenuService : IMenuService
    {
        IMenuRepository _Repository;
        #region Constructors

        public MenuService(IMenuRepository repository)                               
        {
            if (repository == null)
                throw new ArgumentNullException("repository");
            _Repository = repository;
        }

        #endregion

        public MenuDTO Add(MenuDTO menuDTO)
        {
            var menu = menuDTO.ToModel();
            menu.Id = IdentityGenerator.NewSequentialGuid();
            menu.Created = DateTime.UtcNow;
            if (menu.Name.IsNullOrBlank())
                throw new DataExistsException(UserSystemResource.Common_Name_Empty);
            if (_Repository.Exists(menu))
                throw new DataExistsException(UserSystemResource.Menu_Exists);
            _Repository.Add(menu);
            //commit the unit of work
            _Repository.UnitOfWork.Commit();
            return menu.ToDto();
        }

        public void Update(MenuDTO menuDTO)
        {
            //get persisted item
            var persisted = _Repository.Get(menuDTO.Id);

            if (persisted != null) //if customer exist
            {
                var current = menuDTO.ToModel();
                current.Created = persisted.Created;    //不修改创建时间
                if (current.Name.IsNullOrBlank())
                    throw new DataExistsException(UserSystemResource.Common_Name_Empty);
                if (_Repository.Exists(current))
                    throw new DataExistsException(UserSystemResource.Menu_Exists);
                //Merge changes
                _Repository.Merge(persisted, current);
                //commit unit of work
                _Repository.UnitOfWork.Commit();
            }
            else
            {
                // Not Exists
            }
        }

        public void Remove(Guid id)
        {
            var menu = _Repository.Get(id);

            if (menu != null) //if exist
            {
                _Repository.Remove(menu);
                //commit unit of work
                _Repository.UnitOfWork.Commit();
            }
            else
            {
                throw new DataNotFoundException(UserSystemResource.Menu_NotExists);
            }
        }
        public MenuDTO FindBy(Guid id)
        {
            return _Repository.Get(id).ToDto();
        }

        public IPagedList<MenuDTO> FindBy(MenuQueryModel query)
        {
            var list = _Repository.FindBy(query);
            var result = list.OrderBy(x => x.SortOrder).ToList();
            return new StaticPagedList<MenuDTO>(
                result.Select(x => x.ToDto()),
                query.page.Value,
                query.rows.Value,
                list.TotalItemCount);
        }

        public List<MenuDTO> FindBy(Expression<Func<Menu, bool>> query)
        {
            var list = _Repository.Collection.Where(query).ToList();
            return list.Select(x => x.ToDto()).ToList();
        }
    }
}
