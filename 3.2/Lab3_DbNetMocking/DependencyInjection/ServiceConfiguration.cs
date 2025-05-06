using Microsoft.Extensions.DependencyInjection;
using NetDbMockApp.Interfaces;
using NetDbMockApp.Services;

namespace NetDbMockApp.DependencyInjection
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>();
            services.AddSingleton<INetworkClient, NetworkClient>();
            services.AddSingleton<ILogger, FileLogger>();
            return services;
        }
    }
}