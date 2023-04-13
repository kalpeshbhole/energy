using StoreAPI.Storage.Interfaces;
using StoreAPI.Storage.Providers;
using StoreAPI.Storage.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StorageExtensions
    {
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            services.AddSingleton<IDbConnectionProvider, DbConnectionProvider>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

