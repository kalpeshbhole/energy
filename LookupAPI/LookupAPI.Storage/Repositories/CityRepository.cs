using Dapper;
using LookupAPI.Storage.Interfaces;
using LookupAPI.Storage.Providers;
using System.Data;
using LookupAPI.Domain.Entities;

namespace LookupAPI.Storage.Repositories
{
    internal class CityRepository : ICityRepository
    {
        private readonly IDbConnectionProvider _connectionFactory;
        public CityRepository(IDbConnectionProvider connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spCity_Get";
                var result = await connection.QueryAsync<City>(sqlProc, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<City>> GetCitiesByStateIdAsync(int stateId)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spCity_Get";
                var result = await connection.QueryAsync<City>(sqlProc, new {StateId = stateId}, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
