using MIS.Backend.Common.Interfaces;

namespace MIS.Backend.Common
{
    public class ConfigurationHelper : IConfigurationHelper
    {
        public string ConnectionString { get; set; }
        public string ApiKey { get; set; }
    }
}