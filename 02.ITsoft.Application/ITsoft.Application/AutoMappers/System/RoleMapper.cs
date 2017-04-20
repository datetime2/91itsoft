using AutoMapper;
using ITsoft.Application.DTOs;
using ITsoft.Domain.Aggregates;

namespace ITsoft.Application.AutoMappers
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
