using Microsoft.Extensions.DependencyInjection;
using MIS.Backend.PiModules.Interfaces;

namespace MIS.Backend.PiModules.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void ConfigurePiModules(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ISolenoid, Solenoid>();
    }
}