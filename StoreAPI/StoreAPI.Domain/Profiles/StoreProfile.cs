using AutoMapper;

namespace StoreAPI.Domain.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Models.Store, Entities.Store>().ReverseMap();
            CreateMap<Contracts.Dtos.Store, Models.Store>().ReverseMap();
        }
    }
}
