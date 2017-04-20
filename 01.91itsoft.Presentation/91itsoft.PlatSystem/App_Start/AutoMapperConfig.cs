using _91itsoft.Application.DTOs;
using _91itsoft.Domain.Aggregates;
using AutoMapper;

namespace _91itsoft.PlatSystem
{
    public class AutoMapperConfig
    {
        public static void initConfig()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<Role, RoleDTO>();
                cfg.CreateMap<RoleDTO, Role>();
                cfg.CreateMap<RoleGroup, RoleGroupDTO>();
                cfg.CreateMap<RoleGroupDTO, RoleGroup>();
            });
        }
    }
}