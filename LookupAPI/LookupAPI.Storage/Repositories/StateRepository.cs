using Dapper;
using LookupAPI.Domain.Entities;
using LookupAPI.Storage.Interfaces;
using LookupAPI.Storage.Providers;
using System.Data;


namespace LookupAPI.Storage.Repositories
{
    internal class StateRepository: IStateRepository
    {
        private readonly IDbConnectionProvider _connectionFactory;
        public StateRepository(IDbConnectionProvider connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spState_Get";
                var result = await connection.QueryAsync<State>(sqlProc, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<State>> GetStatesByCountryIdAsync(int countryId)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spState_Get";
                var result = await connection.QueryAsync<State>(sqlProc, new { CountryId = countryId }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
