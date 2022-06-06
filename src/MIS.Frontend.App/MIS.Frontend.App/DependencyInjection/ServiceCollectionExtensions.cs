using Microsoft.Extensions.DependencyInjection;
using MIS.Common.Client.DependencyInjection;
using MIS.Common.Client.Interfaces;
using MIS.Frontend.App.Configuration;
using MIS.Frontend.App.Factories;
using MIS.Frontend.App.Factories.Interfaces;
using MIS.Frontend.App.ViewModels;
using MIS.Frontend.App.Views;

namespace MIS.Frontend.App.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddXamarin(this IServiceCollection serviceCollection)
        {
            serviceCollection.ConfigureClient();
            serviceCollection.AddTransient<MainPage>();
            serviceCollection.AddTransient<MainPageViewModel>();
            serviceCollection.AddSingleton<IViewModelFactory, ViewModelFactory>();
            serviceCollection.AddSingleton<IClientConfiguration, ClientConfiguration>();
        }
    }
}