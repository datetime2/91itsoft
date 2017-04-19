using System.Linq;
using AutoMapper;
using _91itsoft.Application.DTOs;
using _91itsoft.Domain.Aggregates.MenuAgg;

namespace _91itsoft.Application.Converters
{
    public static partial class SystemConverters
    {
        public static void InitMenuMappers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Menu, MenuDTO>()
                .ForMember(x => x.Permissions, opt => opt.MapFrom(s => s.Permissions.Select(x => x.ToDto()).ToList()));
                cfg.CreateMap<MenuDTO, Menu>()
                .ForMember(x => x.Permissions, opt => opt.MapFrom(s => s.Permissions.Select(x => x.ToModel()).ToList()));
                cfg.CreateMap<Permission, PermissionDTO>();
                cfg.CreateMap<PermissionDTO, Permission>();
            });
        }
        public static Menu ToModel(this MenuDTO dto)
        {
            return Mapper.Map<Menu>(dto);
        }
        public static MenuDTO ToDto(this Menu model)
        {
            return Mapper.Map<MenuDTO>(model);
        }
        public static Permission ToModel(this PermissionDTO dto)
        {
            return Mapper.Map<Permission>(dto);
        }
        public static PermissionDTO ToDto(this Permission model)
        {
            return Mapper.Map<PermissionDTO>(model);
        }
    }
}
