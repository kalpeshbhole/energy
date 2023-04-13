using AutoMapper;

namespace LookupAPI.Domain.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Models.Country, Entities.Country>().ReverseMap();
            CreateMap<Contracts.Dtos.Country, Models.Country>().ReverseMap();
        }
    }
}
