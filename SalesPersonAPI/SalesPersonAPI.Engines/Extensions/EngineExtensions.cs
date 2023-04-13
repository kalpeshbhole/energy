using SalesPersonAPI.Engines;
using SalesPersonAPI.Engines.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EngineExtensions
    {
        public static IServiceCollection AddEngines(this IServiceCollection services)
        {
            services.AddScoped<ISalesPersonEngine, SalesPersonEngine>();
            services.AddScoped<IUserEngine, UserEngine>();
           
            return services;
        }
    }
}

