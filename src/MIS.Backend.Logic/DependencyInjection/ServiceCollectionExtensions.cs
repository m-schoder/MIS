using Microsoft.Extensions.DependencyInjection;
using MIS.Backend.DataAccess.DependencyInjection;
using MIS.Backend.Logic.Interfaces;
using MIS.Backend.Mappers.DependencyInjection;
using MIS.Backend.PiModules.DependencyInjection;
using IConfigurationProxy = MIS.Backend.PiModules.Interfaces.IConfigurationProxy;

namespace MIS.Backend.Logic.DependencyInjection;
public static class ServiceCollectionExtensions
{
    public static void ConfigureLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.ConfigurePiModules();
        serviceCollection.ConfigureDataAccess();
        serviceCollection.ConfigureMappers();

        serviceCollection.AddTransient<ISolenoidLogic, SolenoidLogic>();
        serviceCollection.AddTransient<IConfigurationLogic, ConfigurationLogic>();

        serviceCollection.AddTransient<IConfigurationProxy, ConfigurationProxy>();
    }
}