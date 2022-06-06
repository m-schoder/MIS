using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MIS.Middleware.Processor.DependencyInjection;
using MIS.Middleware.Processor.Services;
using MIS.Middleware.Processor.Workers;

namespace MIS.Middleware.Processor;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureProcessor();
        services.AddGrpc();
        services.AddHostedService<ConfigurationWorker>();
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHttpsRedirection();
        }
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGrpcService<GrpcService>();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
            });
        });
    }
}