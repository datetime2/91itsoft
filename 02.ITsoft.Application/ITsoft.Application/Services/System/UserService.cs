using System;
using System.Collections.Generic;
using System.Linq;
using ITsoft.Application.Exceptions;
using ITsoft.Application.Resources;
using ITsoft.Application.AutoMappers;
using ITsoft.Application.DTOs;
using ITsoft.Domain.Aggregates;
using ITsoft.Entity;
using ITsoft.Infrastructure.Utility.Helper;
using PagedList;
using ITsoft.Domain.IRepository;
using ITsoft.Domain.QueryModel;

namespace ITsoft.Application.Services
{
    public class UserService : IUserService
    {
        IUserRepository _Repository;
        #region Constructors

        public UserService(IUserRepository repository)                               
        {
            if (repository == null)
                throw new ArgumentNullException("repository");
            _Repository = repository;
        }

        #endregion

        public UserDTO Add(UserDTO userDTO)
        {
            var user = userDTO.ToModel();
            user.Id = IdentityGenerator.NewSequentialGuid();
            user.Created = DateTime.UtcNow;
            user.LastLogin = Const.SqlServerNullDateTime;
            user.PwdSalt = Guid.NewGuid().ToString();
            if (user.Name.IsNullOrBlank())
                throw new DataExistsException(UserSystemResource.Common_Name_Empty);
            if (_Repository.Exists(user))
                throw new DataExistsException(UserSystemResource.User_Exists);
            user.LoginPwd = AuthService.EncryptPassword(user.LoginPwd, user.PwdSalt);
            _Repository.Add(user);
            //commit the unit of work
            _Repository.UnitOfWork.Commit();

            return user.ToDto();
        }

        public void Update(UserDTO userDTO)
        {
            //get persisted item
            var persisted = _Repository.Get(userDTO.Id);
            if (persisted != null) //if customer exist
            {
                var current = userDTO.ToModel();
                current.Created = persisted.Created;    //不修改创建时间
                //current.LoginPwd = persisted.LoginPwd;    //不修改密码
                if (current.LastLogin == DateTime.MinValue)    //最后登录时间字段为空时，数据为datetime默认的{0001/1/1 0:00:00}，新增或修改用户时报错
                    current.LastLogin = Const.SqlServerNullDateTime;
                if (current.Name.IsNullOrBlank())
                    throw new DataExistsException(UserSystemResource.Common_Name_Empty);
                if (current.Email.IsNullOrBlank())
                    throw new DataExistsException(UserSystemResource.Common_Email_Empty);
                if (_Repository.Exists(current))
                    throw new DataExistsException(UserSystemResource.User_Exists);
                if (_Repository.ExistsLoginName(current))
                    throw new DataExistsException(string.Format(UserSystemResource.LoginName_Exists, current.LoginName));
                if (_Repository.ExistsEmail(current))
                    throw new DataExistsException(string.Format(UserSystemResource.Email_Exists, current.Email));
                //Merge changes
                _Repository.Merge(persisted, current);
                //commit unit of work
                _Repository.UnitOfWork.Commit();
            }
            else
            {
                throw new DataNotFoundException(UserSystemResource.User_NotExists);
            }
        }

        public void Remove(Guid id)
        {
            var user = _Repository.Get(id);
            if (user != null) //if exist
            {
                _Repository.Remove(user);
                //commit unit of work
                _Repository.UnitOfWork.Commit();
            }
            else
            {
                // Not Exists
            }
        }
        public UserDTO FindBy(Guid id)
        {
            return _Repository.Get(id).ToDto();
        }


        public IPagedList<UserDTO> FindBy(UserQueryModel query)
        {
            var list = _Repository.FindBy(query);
            return new StaticPagedList<UserDTO>(
               list.ToList().Select(x => x.ToDto()),
               query.page.Value,
               query.rows.Value,
               list.TotalItemCount);
        }
        public List<IdNameDTO> GetAllUsersIdName()
        {
            return _Repository.Collection.Select(x => new IdNameDTO()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
