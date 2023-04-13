using AutoMapper;
using StoreAPI.Domain.Models;
using StoreAPI.Engines.Interfaces;
using StoreAPI.Storage.Interfaces;

namespace StoreAPI.Engines
{
    internal class StoreEngine : IStoreEngine
    {
        private readonly IMapper _mapper;
        private readonly IStoreRepository _storeRepository;


        public StoreEngine(IMapper mapper, IStoreRepository storeRepository) {
            _mapper = mapper;
            _storeRepository = storeRepository;
        }

        async Task<int> IStoreEngine.CreateStoreAsync(Store store)
        {
            var storeEntity = _mapper.Map<Domain.Entities.Store>(store);
            return await _storeRepository.CreateStoreAsync(storeEntity);
        }

        async Task<IEnumerable<Store>> IStoreEngine.GetStoresAsync()
        {
            var stores = await _storeRepository.GetStoresAsync();
            return _mapper.Map<IEnumerable<Store>>(stores);
        }

        async Task<Store> IStoreEngine.GetStoreByIdAsync(int storeId)
        {
            var store = await _storeRepository.GetStoreByIdAsync(storeId);
            return _mapper.Map<Store>(store);
        }

        async Task<IEnumerable<Store>> IStoreEngine.GetStoresByStateIdAsync(int stateId)
        {
            var stores = await _storeRepository.GetStoresByStateIdAsync(stateId);
            return _mapper.Map<IEnumerable<Store>>(stores);
        }
    }
}
