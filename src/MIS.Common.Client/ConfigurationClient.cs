using System.Threading.Tasks;
using MIS.Common.Client.Interfaces;
using MIS.Common.DataTransferObjects.Configuration;

namespace MIS.Common.Client
{
    public class ConfigurationClient : IConfigurationClient
    {
        private readonly IServiceClient _serviceClient;

        public ConfigurationClient(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public Task<GetConfigurationValuesResponse> GetConfigurationValues()
        {
            return _serviceClient.Get<GetConfigurationValuesResponse>("config");
        }

        public Task<GetConfigurationValueResponse> GetConfigurationValue(string name)
        {
            return _serviceClient.Get<GetConfigurationValueResponse>($"config/{name}");
        }

        public Task<CreateConfigurationValueResponse> CreateConfigurationValue(CreateConfigurationValueRequest request)
        {
            return _serviceClient.Post<CreateConfigurationValueResponse, CreateConfigurationValueRequest>("config", request);
        }

        public Task<UpdateConfigurationValueResponse> UpdateConfigurationValue(string name, UpdateConfigurationValueRequest request)
        {
            return _serviceClient.Put<UpdateConfigurationValueResponse, UpdateConfigurationValueRequest>($"config/{name}", request);
        }

        public Task DeleteConfigurationValue(string name)
        {
            return _serviceClient.Delete($"config/{name}");
        }
    }
}