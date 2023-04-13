
namespace SalesPersonAPI.Storage.Providers
{
    using SalesPersonAPI.Domain.Configurations;
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
