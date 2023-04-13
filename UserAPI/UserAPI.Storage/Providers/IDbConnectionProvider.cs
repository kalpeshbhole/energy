
namespace UserAPI.Storage.Providers
{
    using System.Data;

    public interface IDbConnectionProvider
    {
        IDbConnection GetDbConnection();
    }
}
