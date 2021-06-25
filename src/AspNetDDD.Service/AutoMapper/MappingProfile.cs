using AspNetDDD.Domain;
using AutoMapper;

namespace AspNetDDD.Service.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}