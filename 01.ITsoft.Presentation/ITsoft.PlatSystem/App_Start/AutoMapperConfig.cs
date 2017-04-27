using ITsoft.Application.DTOs;
using ITsoft.Domain.Aggregates;
using AutoMapper;

namespace ITsoft.PlatSystem
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
            });
        }
    }
}