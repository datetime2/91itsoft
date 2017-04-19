using AutoMapper;
using _91itsoft.Application.DTOs;
using _91itsoft.Domain.Aggregates.UserAgg;

namespace _91itsoft.Application.Converters
{
    public static partial class SystemConverters
    {
        public static void InitUserMappers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });
        }
        public static User ToModel(this UserDTO dto)
        {
            return Mapper.Map<User>(dto);
        }

        public static UserDTO ToDto(this User model)
        {
            return Mapper.Map<UserDTO>(model);
        }
    }
}
