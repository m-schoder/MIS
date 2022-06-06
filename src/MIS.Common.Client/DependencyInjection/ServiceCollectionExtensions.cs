using Microsoft.Extensions.DependencyInjection;
using MIS.Common.Client.Interfaces;
using RestSharp;

namespace MIS.Common.Client.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureClient(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISolenoidClient, SolenoidClient>();
            serviceCollection.AddTransient<IConfigurationClient, ConfigurationClient>();
            serviceCollection.AddSingleton<IServiceClient, ServiceClient>();
        }
    }
}