using Microsoft.Extensions.DependencyInjection;
using UserAPI.Engines;
using UserAPI.Engines.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EngineExtensions
    {
        public static IServiceCollection AddEngines(this IServiceCollection services)
        {
            services.AddScoped<IUserEngine, UserEngine>();
           
            return services;
        }
    }
}

