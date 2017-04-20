using AutoMapper;
using _91itsoft.Application.DTOs;
using _91itsoft.Domain.Aggregates;

namespace _91itsoft.Application.AutoMappers
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
