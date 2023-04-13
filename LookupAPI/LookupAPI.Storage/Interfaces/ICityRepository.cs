using LookupAPI.Domain.Entities;

namespace LookupAPI.Storage.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();

        Task<IEnumerable<City>> GetCitiesByStateIdAsync(int stateId);
    }
}
