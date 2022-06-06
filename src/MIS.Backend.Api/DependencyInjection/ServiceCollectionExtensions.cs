using System;
using Microsoft.Extensions.DependencyInjection;
using MIS.Backend.Common;
using MIS.Backend.Common.DependencyInjection;
using MIS.Backend.Common.Interfaces;
using MIS.Backend.Logic.DependencyInjection;

namespace MIS.Backend.Api.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void ConfigureApi(this IServiceCollection serviceCollection, Action<IConfigurationHelper> configuration)
    {
        serviceCollection.ConfigureCommon(configuration);
        serviceCollection.ConfigureLogic();
        serviceCollection.AddSingleton<IConfigurationHelper, ConfigurationHelper>(factory =>
        {
            var configurationHelper = new ConfigurationHelper();
            configuration(configurationHelper);
            return configurationHelper;
        });
    }
}