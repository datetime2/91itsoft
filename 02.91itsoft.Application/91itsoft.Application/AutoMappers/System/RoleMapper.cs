using AutoMapper;
using _91itsoft.Application.DTOs;
using _91itsoft.Domain.Aggregates;

namespace _91itsoft.Application.AutoMappers
{
    public static partial class SystemMapper
    {
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
