using Dapper;
using SalesPersonAPI.Storage.Interfaces;
using SalesPersonAPI.Domain.Entities;
using SalesPersonAPI.Storage.Providers;
using System.Data;


namespace SalesPersonAPI.Storage.Repositories
{
    internal class SalesPersonRepository: ISalesPersonRepository
    {
        private readonly IDbConnectionProvider _connectionFactory;
        public SalesPersonRepository(IDbConnectionProvider connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> CreateSalesPersonAsync(SalesPerson salesPerson)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spSalesPerson_Insert";
                var salesPersonParameter = new {
                    FirstName = salesPerson.FirstName, MiddleName = salesPerson.MiddleName,
                    LastName = salesPerson.LastName, UserId = salesPerson.CreateByUserId };
                return await connection.QuerySingleAsync<int>(sqlProc, salesPersonParameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<SalesPerson>> GetSalesPersonsAsync()
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spSalesPerson_Get";
                var result = await connection.QueryAsync<SalesPerson>(sqlProc, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<SalesPerson> GetSalesPersonByIdAsync(int id)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spSalesPerson_Get";
                return await connection.QueryFirstOrDefaultAsync<SalesPerson>(sqlProc, new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }


        public async Task<IEnumerable<SalesPerson>> GetSalesPersonsByStateIdAsync(int stateId)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spSalesPersonByStateId_Get";
                var result = await connection.QueryAsync<SalesPerson>(sqlProc, new { StateId = stateId }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
