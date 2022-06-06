using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MIS.Backend.Common.Interfaces;
using static MIS.Common.Constants.Constants;

namespace MIS.Backend.Api.Middleware;

[PublicAPI]
public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfigurationHelper _configurationHelper;

    public ApiKeyMiddleware(RequestDelegate next, IConfigurationHelper configurationHelper)
    {
        _next = next;
        _configurationHelper = configurationHelper;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(API_KEY, out var extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Api Key was not provided ");
            //return HttpStatusCode.Unauthorized;
        }

        var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
        if (!_configurationHelper.ApiKey.Equals(extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized client");
            //return HttpStatusCode.Unauthorized;
        }

        await _next(context);
        //return HttpStatusCode.OK;
    }
}