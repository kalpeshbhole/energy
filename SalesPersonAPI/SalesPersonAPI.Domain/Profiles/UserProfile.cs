using AutoMapper;

namespace SalesPersonAPI.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Models.User, Entities.User>().ReverseMap();
        }
    }
}
