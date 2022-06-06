using System;
using Microsoft.Extensions.DependencyInjection;
using MIS.Backend.Common.Interfaces;

namespace MIS.Backend.Common.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureCommon(this IServiceCollection serviceCollection, Action<IConfigurationHelper> configuration)
        {
            serviceCollection.AddSingleton<IConfigurationHelper, ConfigurationHelper>(factory =>
            {
                var configurationHelper = new ConfigurationHelper();
                configuration(configurationHelper);
                return configurationHelper;
            });
        }
    }
}