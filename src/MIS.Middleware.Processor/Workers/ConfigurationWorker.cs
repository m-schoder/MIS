using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using MIS.Common.Client.Interfaces;
using MIS.Common.DataTransferObjects.Configuration;
using static MIS.Common.Constants.Constants;

namespace MIS.Middleware.Processor.Workers;

public class ConfigurationWorker : BackgroundService
{
    private readonly IConfigurationClient _configurationClient;

    public ConfigurationWorker(IConfigurationClient configurationClient)
    {
        _configurationClient = configurationClient;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var configResponse = await _configurationClient.GetConfigurationValue(MIDDLEWARE_HOST_ADDRESS);
                    var myAdress = GetPublicIPv4Address();
                    if (configResponse != null && myAdress != null)
                    {
                        if (configResponse.Value != myAdress)
                        {
                            var updateRequest = new UpdateConfigurationValueRequest()
                            {
                                Value = myAdress
                            };
                            await _configurationClient.UpdateConfigurationValue(MIDDLEWARE_HOST_ADDRESS, updateRequest);
                        }
                    }
                    else
                    {
                        var createRequest = new CreateConfigurationValueRequest()
                        {
                            Name = MIDDLEWARE_HOST_ADDRESS,
                            Value = myAdress
                        };
                        await _configurationClient.CreateConfigurationValue(createRequest);
                    }

                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                }
                catch (TaskCanceledException)
                {
                    // This is most likely due to the Task.Delay being cancelled.
                }
            }
        }
        catch
        {
            // ignored
        }
    }

    public static string GetPublicIPv4Address()
    {
        try
        {
            var ip = new HttpClient().GetStringAsync("https://ipinfo.io/ip").GetAwaiter().GetResult().Replace("\n", "");
            return "https://" + ip + ":5050/";
        }
        catch (HttpRequestException) // Happens if middleware has no internet connection
        {
            // To-Do Logging
        }
        return null;
    }
}