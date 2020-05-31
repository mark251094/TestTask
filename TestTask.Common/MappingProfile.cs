using AutoMapper;
using TestTask.Common.Models;
using TestTask.DataAccess.Entities;

namespace TestTask.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreateModel, User>();
            CreateMap<User, UserViewModel>();
            CreateMap<UserUpdateModel, User>();
        }
    }
}
