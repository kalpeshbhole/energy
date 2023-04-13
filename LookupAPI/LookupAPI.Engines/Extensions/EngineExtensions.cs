using LookupAPI.Engines;
using LookupAPI.Engines.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EngineExtensions
    {
        public static IServiceCollection AddEngines(this IServiceCollection services)
        {
            services.AddScoped<ILookupEngine, LookupEngine>();
            services.AddScoped<IUserEngine, UserEngine>();
           
            return services;
        }
    }
}

