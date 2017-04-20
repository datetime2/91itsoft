using AutoMapper;
using ITsoft.Application.DTOs;
using ITsoft.Domain.Aggregates;

namespace ITsoft.Application.AutoMappers
{
    public static partial class SystemMapper
    {
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
