using Microsoft.Extensions.DependencyInjection;
using MIS.Common.Client.DependencyInjection;
using MIS.Common.Client.Interfaces;
using MIS.Middleware.Processor.Configuration;
using MIS.Middleware.Processor.Controllers;
using MIS.Middleware.Processor.Controllers.Interfaces;
using MIS.Middleware.Processor.Services;
using MIS.Middleware.Processor.Services.Interfaces;

namespace MIS.Middleware.Processor.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void ConfigureProcessor(this IServiceCollection serviceCollection)
    {
        serviceCollection.ConfigureClient();
        serviceCollection.AddSingleton<IClientConfiguration, ClientConfiguration>();
        serviceCollection.AddSingleton<IGpioService, GpioService>();
        serviceCollection.AddSingleton<IGpioController, GpioController>();
    }
}