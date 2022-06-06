using Microsoft.Extensions.DependencyInjection;
using MIS.Backend.DataAccess.Interfaces;
using MIS.Backend.DataAccess.Repositories;
using MIS.Backend.Models;

namespace MIS.Backend.DataAccess.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void ConfigureDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IRepository<ConfigurationValue>, ConfigurationValueRepository>();
        serviceCollection.AddDbContext<DatabaseContext>();
    }
}