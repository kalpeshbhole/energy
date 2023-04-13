using StoreAPI.Domain.Entities;

namespace StoreAPI.Storage.Interfaces
{
    public interface IStoreRepository
    {
        Task<int> CreateStoreAsync(Store store);
        Task<IEnumerable<Store>> GetStoresAsync();
        Task<IEnumerable<Store>> GetStoresByStateIdAsync(int stateId);
    }
}
