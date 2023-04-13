using Dapper;
using System.Data;
using LookupAPI.Domain.Entities;
using LookupAPI.Storage.Interfaces;
using LookupAPI.Storage.Providers;

namespace LookupAPI.Storage.Repositories
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
