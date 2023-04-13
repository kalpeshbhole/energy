using Dapper;
using System.Data;
using SalesPersonAPI.Domain.Entities;
using SalesPersonAPI.Storage.Interfaces;
using SalesPersonAPI.Storage.Providers;

namespace SalesPersonAPI.Storage.Repositories
{
    internal class UserRepository: IUserRepository
    {
        private readonly IDbConnectionProvider _connectionFactory;
        public UserRepository(IDbConnectionProvider connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spUser_Get";
                return await connection.QueryFirstOrDefaultAsync<User>(sqlProc, new { UserId = userId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
