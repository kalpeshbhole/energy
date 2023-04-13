using StoreAPI.Engines;
using StoreAPI.Engines.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EngineExtensions
    {
        public static IServiceCollection AddEngines(this IServiceCollection services)
        {
            services.AddScoped<IStoreEngine, StoreEngine>();
            services.AddScoped<IUserEngine, UserEngine>();
           
            return services;
        }
    }
}

