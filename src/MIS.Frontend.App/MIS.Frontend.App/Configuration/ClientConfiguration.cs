using MIS.Common.Client.Interfaces;

namespace MIS.Frontend.App.Configuration
{
    public class ClientConfiguration : IClientConfiguration
    {
        public string ServiceBaseUrl { get; set; }
        public string ApiKey { get; set; }
    }
}