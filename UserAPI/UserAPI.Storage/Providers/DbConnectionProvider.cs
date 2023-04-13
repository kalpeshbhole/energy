
namespace UserAPI.Storage.Providers
{
    using UserAPI.Domain.Configurations;
    using System.Data;
    using System.Data.SqlClient;

    public class DbConnectionProvider : IDbConnectionProvider
    {
        private ConnectionStrings _connectionStrings;

        public DbConnectionProvider(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_connectionStrings.SalesDbContext);
        }
    }
}
