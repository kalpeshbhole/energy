using AutoMapper;

namespace SalesPersonAPI.Domain.Profiles
{
    public class SalesPersonProfile : Profile
    {
        public SalesPersonProfile()
        {
            CreateMap<Models.SalesPerson, Entities.SalesPerson>().ReverseMap();
            CreateMap<Contracts.Dtos.SalesPerson, Models.SalesPerson>().ReverseMap();
        }
    }
}
