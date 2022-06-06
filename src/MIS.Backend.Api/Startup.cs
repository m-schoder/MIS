using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MIS.Backend.Api.DependencyInjection;
using MIS.Backend.Api.Middleware;
using MIS.Backend.Api.Swagger;
using static System.Environment;
using static MIS.Common.Constants.Constants;

namespace MIS.Backend.Api;

public class Startup
{
    public IWebHostEnvironment Environment { get; }
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Environment = env;
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.ConfigureApi(c =>
        {
            if (Environment.IsDevelopment())
            {
                // From User Secrets
                c.ConnectionString = Configuration[CONNECTIONSTRING];
                c.ApiKey = Configuration[API_KEY];
            }
            else
            {
                c.ConnectionString = GetEnvironmentVariable(CONNECTIONSTRING);
                c.ApiKey = GetEnvironmentVariable(API_KEY);
            }

        });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc("v1", new OpenApiInfo { Title = "MIS API", Version = "v1" });
            o.OperationFilter<ApiKeyHeaderOperationFilter>();
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "MIS API v1");
            });
        }
        else
        {
            // Adding the directory .well-known to static files is necessary for certification via Let's Encrypts Certbot
            // After a successful certification those lines could be removed
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @".well-known")),
                RequestPath = new PathString("/.well-known"),
                ServeUnknownFileTypes = true // serve extensionless file
            });
        }
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });
        app.UseMiddleware<ApiKeyMiddleware>();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}