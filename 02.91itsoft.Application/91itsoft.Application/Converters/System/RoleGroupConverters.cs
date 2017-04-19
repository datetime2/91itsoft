using AutoMapper;
using _91itsoft.Application.DTOs;
using _91itsoft.Domain.Aggregates.RoleGroupAgg;

namespace _91itsoft.Application.Converters
{
    public static partial class SystemConverters
    {
        public static void InitRoleGroupMappers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoleGroup, RoleGroupDTO>();
                cfg.CreateMap<RoleGroupDTO, RoleGroup>();
            });
        }

        public static RoleGroup ToModel(this RoleGroupDTO dto)
        {
            return Mapper.Map<RoleGroup>(dto);
        }

        public static RoleGroupDTO ToDto(this RoleGroup model)
        {
            return Mapper.Map<RoleGroupDTO>(model);
        }
    }
}
