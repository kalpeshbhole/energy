using AutoMapper;

namespace StoreAPI.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Models.User, Entities.User>().ReverseMap();
        }
    }
}
