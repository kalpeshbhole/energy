using AutoMapper;

namespace LookupAPI.Domain.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<Models.City, Entities.City>().ReverseMap();
            CreateMap<Contracts.Dtos.City, Models.City>().ReverseMap();
        }
    }
}
