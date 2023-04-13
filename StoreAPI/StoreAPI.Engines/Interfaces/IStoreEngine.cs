using StoreAPI.Domain.Models;

namespace StoreAPI.Engines.Interfaces
{
    public interface IStoreEngine
    {
        Task<int> CreateStoreAsync(Store store);
        Task<IEnumerable<Store>> GetStoresAsync();
        Task<Store> GetStoreByIdAsync(int storeId);
        Task<IEnumerable<Store>> GetStoresByStateIdAsync(int stateId);
    }
}
