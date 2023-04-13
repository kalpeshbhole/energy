
namespace StoreAPI.Storage.Providers
{
    using System.Data;

    public interface IDbConnectionProvider
    {
        IDbConnection GetDbConnection();
    }
}
