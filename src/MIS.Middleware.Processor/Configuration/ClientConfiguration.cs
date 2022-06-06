using Microsoft.Extensions.Configuration;
using MIS.Common.Client.Interfaces;
using static MIS.Common.Constants.Constants;

namespace MIS.Middleware.Processor.Configuration;

public class ClientConfiguration : IClientConfiguration
{
    public string ServiceBaseUrl { get; set; }
    public string ApiKey { get; set; }

    public ClientConfiguration(IConfiguration configuration)
    {
        ServiceBaseUrl = configuration[SERVICE_BASE_URL];
        ApiKey = configuration[API_KEY];
    }
}