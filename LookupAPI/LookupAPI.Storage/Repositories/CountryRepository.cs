using Dapper;
using LookupAPI.Domain.Entities;
using LookupAPI.Storage.Interfaces;
using LookupAPI.Storage.Providers;
using System.Data;

namespace LookupAPI.Storage.Repositories
{
    internal class CountryRepository: ICountryRepository
    {
        private readonly IDbConnectionProvider _connectionFactory;
        public CountryRepository(IDbConnectionProvider connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spCountry_Get";
                var result = await connection.QueryAsync<Country>(sqlProc, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
