using AutoMapper;

namespace SalesPersonAPI.Domain.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Models.Region, Entities.SalesPersonRegionXref>().ReverseMap();
            CreateMap<Contracts.Dtos.Region, Models.Region>().ReverseMap();
        }
    }
}
