using LookupAPI.Storage.Interfaces;
using LookupAPI.Storage.Providers;
using LookupAPI.Storage.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StorageExtensions
    {
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            services.AddSingleton<IDbConnectionProvider, DbConnectionProvider>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

