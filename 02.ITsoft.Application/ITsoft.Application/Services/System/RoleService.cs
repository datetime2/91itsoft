using System;
using System.Collections.Generic;
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

namespace ITsoft.Application.Services
{
    public class RoleService : IRoleService
    {
        IRoleRepository _Repository;
        IMenuRepository _menuRepository;
        #region Constructors

        public RoleService(IRoleRepository repository, IMenuRepository menuRepository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");
            _Repository = repository;
            _menuRepository = menuRepository;
        }

        #endregion

        public RoleDTO Add(RoleDTO roleDTO)
        {
            var role = roleDTO.ToModel();
            role.Id = IdentityGenerator.NewSequentialGuid();
            role.Created = DateTime.UtcNow;
            if (role.Name.IsNullOrBlank())
                throw new DataExistsException(UserSystemResource.Common_Name_Empty);
            if (_Repository.Exists(role))
                throw new DataExistsException(UserSystemResource.Role_Exists);
            _Repository.Add(role);
            //commit the unit of work
            _Repository.UnitOfWork.Commit();
            return role.ToDto();
        }

        public void Update(RoleDTO roleDTO)
        {
            //get persisted item
            var persisted = _Repository.Get(roleDTO.Id);

            if (persisted != null) //if customer exist
            {
                var current = roleDTO.ToModel();
                current.Created = persisted.Created;    //不修改创建时间
                if (current.Name.IsNullOrBlank())
                    throw new DataExistsException(UserSystemResource.Common_Name_Empty);
                if (_Repository.Exists(current))
                    throw new DataExistsException(UserSystemResource.Role_Exists);
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
            var role = _Repository.Get(id);

            if (role != null) //if exist
            {
                _Repository.Remove(role);
                //commit unit of work
                _Repository.UnitOfWork.Commit();
            }
            else
            {
                throw new DataNotFoundException(UserSystemResource.Role_NotExists);
            }
        }

        public List<RoleDTO> FindAll()
        {
            return _Repository.FindAll().OrderBy(x => x.SortOrder)
                .Select(x => x.ToDto()).ToList();
        }
        public RoleDTO FindBy(Guid id)
        {
            return _Repository.Get(id).ToDto();
        }

        public IPagedList<RoleDTO> FindBy(RoleQueryModel query)
        {
            var list = _Repository.FindBy(query);
            return new StaticPagedList<RoleDTO>(
               list.ToList().Select(x => x.ToDto()),
               query.page.Value,
               query.rows.Value,
               list.TotalItemCount);
        }

        public void UpdateRoleMenu(Guid id, List<Guid> menus)
        {
            //get persisted item
            var persisted = _Repository.Get(id);
            if (menus != null) //if customer exist
            {
                var mList = new List<Menu>();
                foreach (var mid in menus)
                {
                    var p = _menuRepository.Get(mid);
                    if (p != null)
                        mList.Add(p);
                }
                // 删除旧的权限
                persisted.Menus.Clear();
                // 添加新的权限
                persisted.Menus = mList;
                //commit unit of work
                _Repository.UnitOfWork.Commit();
            }
        }
        public List<MenuDTO> GetRoleMenu(Guid id)
        {
            //get persisted item
            var persisted = _Repository.Get(id);
            if (persisted != null) //if customer exist
            {
                return persisted.Menus.Select(x => x.ToDto()).ToList();
            }
            return new List<MenuDTO>();
        }
    }
}
