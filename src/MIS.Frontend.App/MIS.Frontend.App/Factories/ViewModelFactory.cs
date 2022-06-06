using System;
using Microsoft.Extensions.DependencyInjection;
using MIS.Frontend.App.Factories.Interfaces;

namespace MIS.Frontend.App.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TViewModel Get<TViewModel>()
        {
            return _serviceProvider.GetService<TViewModel>();
        }
    }
}