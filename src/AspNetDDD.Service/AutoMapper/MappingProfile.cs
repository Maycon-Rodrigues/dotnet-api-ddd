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

            // CreateMap<UserViewModel, User>()
            //     .ConstructUsing(src => new User(src.Name, src.Email, src.Password));
        }
    }
}