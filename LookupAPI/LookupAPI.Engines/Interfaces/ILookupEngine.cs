using LookupAPI.Domain.Models;

namespace LookupAPI.Engines.Interfaces
{
    public interface ILookupEngine
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<IEnumerable<City>> GetCitiesByStateIdAsync(int stateId);
        Task<IEnumerable<State>> GetStatesAsync();
        Task<IEnumerable<State>> GetStatesByCountryIdAsync(int countryId);
        Task<IEnumerable<Country>> GetCountriesAsync();
    }
}
