using UserAPI.Storage.Interfaces;
using UserAPI.Storage.Providers;
using UserAPI.Storage.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StorageExtensions
    {
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            services.AddSingleton<IDbConnectionProvider, DbConnectionProvider>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

