using AutoMapper;
using _91itsoft.Application.DTOs;
using _91itsoft.Domain.Aggregates.RoleAgg;

namespace _91itsoft.Application.AutoMappers
{
    public static partial class SystemAutoMappers
    {
        public static void InitRoleMappers()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Role, RoleDTO>();
                cfg.CreateMap<RoleDTO, Role>();
            });
        }
        public static Role ToModel(this RoleDTO dto)
        {
            return Mapper.Map<Role>(dto);
        }
        public static RoleDTO ToDto(this Role model)
        {
            return Mapper.Map<RoleDTO>(model);
        }
    }
}
