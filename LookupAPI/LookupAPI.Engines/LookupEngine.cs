using AutoMapper;
using LookupAPI.Domain.Models;
using LookupAPI.Engines.Interfaces;
using LookupAPI.Storage.Interfaces;

namespace LookupAPI.Engines
{
    internal class LookupEngine : ILookupEngine
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICountryRepository _countryRepository;

        public LookupEngine(IMapper mapper, ICityRepository cityRepository, IStateRepository stateRepository, ICountryRepository countryRepository) {
            _mapper = mapper;
            _cityRepository = cityRepository;
            _stateRepository = stateRepository;
            _countryRepository = countryRepository;
        }
        async Task<IEnumerable<City>> ILookupEngine.GetCitiesAsync()
        {
            var cities = await _cityRepository.GetCitiesAsync();
            return _mapper.Map<IEnumerable<City>>(cities);
        }

        async Task<IEnumerable<City>> ILookupEngine.GetCitiesByStateIdAsync(int stateId)
        {
            var cities = await _cityRepository.GetCitiesByStateIdAsync(stateId);
            return _mapper.Map<IEnumerable<City>>(cities);
        }

        async Task<IEnumerable<State>> ILookupEngine.GetStatesAsync()
        {
            var states = await _stateRepository.GetStatesAsync();
            return _mapper.Map<IEnumerable<State>>(states);
        }

        async Task<IEnumerable<State>> ILookupEngine.GetStatesByCountryIdAsync(int countryId)
        {
            var states = await _stateRepository.GetStatesByCountryIdAsync(countryId);
            return _mapper.Map<IEnumerable<State>>(states);
        }

        async Task<IEnumerable<Country>> ILookupEngine.GetCountriesAsync()
        {
            var counties = await _countryRepository.GetCountriesAsync();
            return _mapper.Map<IEnumerable<Country>>(counties);
        }
    }
}
