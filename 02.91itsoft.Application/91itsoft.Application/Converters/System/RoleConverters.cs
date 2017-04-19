using AutoMapper;
using _91itsoft.Application.DTOs;
using _91itsoft.Domain.Aggregates.RoleAgg;

namespace _91itsoft.Application.Converters
{
    public static partial class SystemConverters
    {
        public static void InitRoleMappers()
        {
            var config = new MapperConfiguration(cfg =>
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
