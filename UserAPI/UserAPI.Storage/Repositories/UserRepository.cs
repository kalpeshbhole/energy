using Dapper;
using System.Data;
using UserAPI.Domain.Entities;
using UserAPI.Storage.Interfaces;
using UserAPI.Storage.Providers;

namespace UserAPI.Storage.Repositories
{
    internal class UserRepository: IUserRepository
    {
        private readonly IDbConnectionProvider _connectionFactory;
        public UserRepository(IDbConnectionProvider connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> CreateAsync(User user)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spUser_Insert";
                return await connection.QuerySingleAsync<int>(sqlProc, new { user.FirstName, user.LastName, user.UserName, user.PasswordHash, user.PasswordSalt }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spUser_Get";
                return await connection.QueryFirstOrDefaultAsync<User>(sqlProc, new { UserId = userId }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            using (var connection = _connectionFactory.GetDbConnection())
            {
                var sqlProc = "spUser_Get";
                return await connection.QueryFirstOrDefaultAsync<User>(sqlProc, new { UserName = userName }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
