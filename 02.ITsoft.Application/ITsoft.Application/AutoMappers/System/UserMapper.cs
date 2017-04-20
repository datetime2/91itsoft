using AutoMapper;
using ITsoft.Application.DTOs;
using ITsoft.Domain.Aggregates;

namespace ITsoft.Application.AutoMappers
{
    public static partial class SystemMapper
    {
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
