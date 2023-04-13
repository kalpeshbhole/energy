using AutoMapper;

namespace LookupAPI.Domain.Profiles
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<Models.State, Entities.State>().ReverseMap();
            CreateMap<Contracts.Dtos.State, Models.State>().ReverseMap();
        }
    }
}
