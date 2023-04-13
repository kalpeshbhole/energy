using Dapper;
using SalesPersonAPI.Domain.Entities;
using SalesPersonAPI.Storage.Providers;
using System.Data;

namespace SalesPersonAPI.Storage.Repositories
{
    internal class SalesPersonRegionXrefRepository: ISalesPersonRegionXrefRepository
    {
        private readonly IDbConnectionProvider _connectionFactory;
        public SalesPersonRegionXrefRepository(IDbConnectionProvider connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> CreateSalesPersonRegionXrefAsync(SalesPersonRegionXref salesPersonRegionXref)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spSalesPersonRegionXref_Insert";
                var salesPersonParameter = new
                {
                    SalesPersonId = salesPersonRegionXref.SalesPersonId,
                    CityId = salesPersonRegionXref.CityId,
                    StateId = salesPersonRegionXref.StateId,
                    IsPrimary = salesPersonRegionXref.IsPrimary,
                    UserId = salesPersonRegionXref.CreateByUserId
                };
                return await connection.QuerySingleAsync<int>(sqlProc, salesPersonParameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<SalesPersonRegionXref>> GetSalesPersonRegionXrefsBySalesPersonIdAsync(int salesPersonId)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spSalesPersonRegionXrefBySalesPersonId_Get";
                var result = await connection.QueryAsync<SalesPersonRegionXref>(sqlProc, new { SalesPersonId = salesPersonId }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
