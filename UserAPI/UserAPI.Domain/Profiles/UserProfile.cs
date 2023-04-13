using AutoMapper;

namespace UserAPI.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Models.User, Entities.User>().ReverseMap();
            CreateMap<Contracts.Dtos.User, Models.User>().ReverseMap();
        }
    }
}
