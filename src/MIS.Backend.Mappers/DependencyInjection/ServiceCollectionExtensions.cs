using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using MIS.Backend.Mappers.Interfaces;
using MIS.Common.DataTransferObjects.Configuration;
using ConfigurationValue = MIS.Backend.Models.ConfigurationValue;

namespace MIS.Backend.Mappers.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void ConfigureMappers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMapper<IList<ConfigurationValue>, GetConfigurationValuesResponse>, GetConfigurationValuesResponseMapper>();
        serviceCollection.AddSingleton<IMapper<ConfigurationValue, GetConfigurationValueResponse>, GetConfigurationValueResponseMapper>();
        serviceCollection.AddSingleton<IMapper<CreateConfigurationValueRequest, ConfigurationValue>, CreateConfigurationValueRequestMapper>();
        serviceCollection.AddSingleton<IMapper<ConfigurationValue, CreateConfigurationValueResponse>, CreateConfigurationValueResponseMapper>();
        serviceCollection.AddSingleton<IMapper<UpdateConfigurationValueRequest, ConfigurationValue>, UpdateConfigurationValueRequestMapper>();
        serviceCollection.AddSingleton<IMapper<ConfigurationValue, UpdateConfigurationValueResponse>, UpdateConfigurationValueResponseMapper>();
    }
}