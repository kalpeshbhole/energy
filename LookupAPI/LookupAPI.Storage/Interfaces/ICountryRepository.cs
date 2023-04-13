using LookupAPI.Domain.Entities;

namespace LookupAPI.Storage.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
    }
}
