using Dapper;
using StoreAPI.Domain.Entities;
using StoreAPI.Storage.Interfaces;
using StoreAPI.Storage.Providers;
using System.Data;


namespace StoreAPI.Storage.Repositories
{
    internal class StoreRepository: IStoreRepository
    {
        private readonly IDbConnectionProvider _connectionFactory;
        public StoreRepository(IDbConnectionProvider connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> CreateStoreAsync(Store store)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spStore_Insert";
                var storeParameter = new { 
                    Name = store.Name, 
                    Address1 = store.Address1, Address2 = store.Address2, Address3 = store.Address3, 
                    CityId = store.CityId, StateId = store.StateId, CountryId = store.CountryId, ZipCode = store.ZipCode,
                    UserId = store.CreateByUserId };
                return await connection.QuerySingleAsync<int>(sqlProc, storeParameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Store>> GetStoresAsync()
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spStore_Get";
                var result = await connection.QueryAsync<Store>(sqlProc, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<Store> GetStoreByIdAsync(int storeId)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spStore_Get";
                return await connection.QueryFirstOrDefaultAsync<Store>(sqlProc, new { StoreId = storeId }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Store>> GetStoresByStateIdAsync(int stateId)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spStore_Get";
                var result = await connection.QueryAsync<Store>(sqlProc, new { StateId = stateId }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
