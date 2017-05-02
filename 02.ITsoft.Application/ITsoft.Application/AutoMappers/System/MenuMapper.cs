using AutoMapper;
using ITsoft.Application.DTOs;
using ITsoft.Domain.Aggregates;

namespace ITsoft.Application.AutoMappers
{
    public static partial class SystemMapper
    {
        public static Menu ToModel(this MenuDTO dto)
        {
            return Mapper.Map<Menu>(dto);
        }
        public static MenuDTO ToDto(this Menu model)
        {
            return Mapper.Map<MenuDTO>(model);
        }
    }
}
