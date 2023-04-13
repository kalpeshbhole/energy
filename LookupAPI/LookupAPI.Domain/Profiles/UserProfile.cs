using AutoMapper;

namespace LookupAPI.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Models.User, Entities.User>().ReverseMap();
        }
    }
}
