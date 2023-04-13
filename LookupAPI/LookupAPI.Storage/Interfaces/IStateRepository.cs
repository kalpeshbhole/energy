using LookupAPI.Domain.Entities;

namespace LookupAPI.Storage.Interfaces
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetStatesAsync();

        Task<IEnumerable<State>> GetStatesByCountryIdAsync(int countryId);
    }
}
