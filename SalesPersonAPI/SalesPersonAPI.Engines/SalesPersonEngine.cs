using AutoMapper;
using SalesPersonAPI.Domain.Models;
using SalesPersonAPI.Engines.Interfaces;
using SalesPersonAPI.Storage.Interfaces;
using SalesPersonAPI.Storage.Repositories;

namespace SalesPersonAPI.Engines
{
    internal class SalesPersonEngine : ISalesPersonEngine
    {
        private readonly IMapper _mapper;
        private readonly ISalesPersonRepository _salesPersonRepository;
        private readonly ISalesPersonRegionXrefRepository _salesPersonRegionXrefRepository;

        public SalesPersonEngine(IMapper mapper, ISalesPersonRepository salesPersonRepository, ISalesPersonRegionXrefRepository salesPersonRegionXrefRepository) {
            _mapper = mapper;
            _salesPersonRepository = salesPersonRepository;
            _salesPersonRegionXrefRepository = salesPersonRegionXrefRepository;
        }

        async Task<int> ISalesPersonEngine.CreateSalesPersonAsync(SalesPerson salesPerson)
        {
            var salesPersonEntity = _mapper.Map<Domain.Entities.SalesPerson>(salesPerson);

            int salesPersonId = await _salesPersonRepository.CreateSalesPersonAsync(salesPersonEntity);


            foreach(Region region in salesPerson.Regions)
            {
                var salesPersonRegionXref = new Domain.Entities.SalesPersonRegionXref
                {
                    SalesPersonId = salesPersonId,
                    StateId = region.StateId,
                    IsPrimary = region.IsPrimary,
                    CreateByUserId = salesPerson.CreateByUserId

                };
                await _salesPersonRegionXrefRepository.CreateSalesPersonRegionXrefAsync(salesPersonRegionXref);
            }

            return salesPersonId;
        }

        async Task<IEnumerable<SalesPerson>> ISalesPersonEngine.GetSalesPersonsAsync()
        {
            var salesPersons = await _salesPersonRepository.GetSalesPersonsAsync();
            return _mapper.Map<IEnumerable<SalesPerson>>(salesPersons);
        }

        async Task<SalesPerson> ISalesPersonEngine.GetSalesPersonByIdAsync(int id)
        {
            var salesPerson = await _salesPersonRepository.GetSalesPersonByIdAsync(id);
            SalesPerson salesPersonModel = _mapper.Map<SalesPerson>(salesPerson);

            var regions = await _salesPersonRegionXrefRepository.GetSalesPersonRegionXrefsBySalesPersonIdAsync(id);
            IEnumerable<Region> regionModels = _mapper.Map<IEnumerable<Region>>(regions);

            salesPersonModel.Regions = regionModels;

            return salesPersonModel;
        }

        async Task<IEnumerable<SalesPerson>> ISalesPersonEngine.GetSalesPersonsByStateIdAsync(int stateId)
        {
            var salesPersons = await _salesPersonRepository.GetSalesPersonsByStateIdAsync(stateId);
            return _mapper.Map<IEnumerable<SalesPerson>>(salesPersons);
        }
    }
}
