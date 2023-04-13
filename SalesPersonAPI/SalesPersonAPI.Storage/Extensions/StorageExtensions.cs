using SalesPersonAPI.Storage.Interfaces;
using SalesPersonAPI.Storage.Providers;
using SalesPersonAPI.Storage.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StorageExtensions
    {
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            services.AddSingleton<IDbConnectionProvider, DbConnectionProvider>();
            services.AddScoped<ISalesPersonRepository, SalesPersonRepository>();
            services.AddScoped<ISalesPersonRegionXrefRepository, SalesPersonRegionXrefRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

