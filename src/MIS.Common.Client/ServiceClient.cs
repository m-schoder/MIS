using System.Net;
using System.Threading.Tasks;
using MIS.Common.Client.Interfaces;
using MIS.Common.DataTransferObjects;
using RestSharp;
using static MIS.Common.Constants.Constants;

namespace MIS.Common.Client
{
    public class ServiceClient : IServiceClient
    {
        private readonly IClientConfiguration _clientConfiguration;
        private RestClient _restClient;

        public ServiceClient(IClientConfiguration clientConfiguration)
        {
            _clientConfiguration = clientConfiguration;
            if (_clientConfiguration.ServiceBaseUrl != null)
            {
                _restClient = new RestClient(_clientConfiguration.ServiceBaseUrl);
            }
        }

        public async Task ReloadConfiguration()
        {
            _restClient = await Task.Run(() => new RestClient(_clientConfiguration.ServiceBaseUrl));
        }

        public async Task<TResponse> Get<TResponse>(string resource) where TResponse : new()
        {
            var request = new RestRequest(resource);
            request.AddHeader(API_KEY, _clientConfiguration.ApiKey);
            var response = await _restClient.ExecuteAsync<ApiResult<TResponse>>(request);
            if (response.IsSuccessful && response.StatusCode == HttpStatusCode.OK)
            {
                if (response.Data != null) return response.Data.Content;
            }
            return default;
        }

        public async Task Post(string resource)
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddHeader(API_KEY, _clientConfiguration.ApiKey);
            await _restClient.ExecuteAsync<ApiResult>(request);
        }

        public async Task Post<TBody>(string resource, TBody body) where TBody : class
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddHeader(API_KEY, _clientConfiguration.ApiKey);
            request.AddJsonBody(body);
            var response = await _restClient.ExecuteAsync<ApiResult>(request);
            if (response.IsSuccessful && response.StatusCode == HttpStatusCode.OK)
            {
            }
        }

        public async Task<TResponse> Post<TResponse, TBody>(string resource, TBody body) where TResponse : new() where TBody : class
        {
            var request = new RestRequest(resource, Method.Post);
            request.AddHeader(API_KEY, _clientConfiguration.ApiKey);
            request.AddJsonBody(body);
            var response = await _restClient.ExecuteAsync<ApiResult<TResponse>>(request);
            if (response.IsSuccessful && response.StatusCode == HttpStatusCode.OK)
            {
                if (response.Data != null) return response.Data.Content;
            }

            return default;
        }

        public async Task Put(string resource)
        {
            var request = new RestRequest(resource, Method.Put);
            request.AddHeader(API_KEY, _clientConfiguration.ApiKey);
            await _restClient.ExecuteAsync<ApiResult>(request);
        }

        public async Task<TResponse> Put<TResponse, TBody>(string resource, TBody body) where TResponse : new() where TBody : class
        {
            var request = new RestRequest(resource, Method.Put);
            request.AddHeader(API_KEY, _clientConfiguration.ApiKey);
            request.AddJsonBody(body);
            var response = await _restClient.ExecuteAsync<ApiResult<TResponse>>(request);
            if (response.IsSuccessful && response.StatusCode == HttpStatusCode.OK)
            {
                if (response.Data != null) return response.Data.Content;
            }
            return default;
        }

        public async Task Delete(string resource)
        {
            var request = new RestRequest(resource, Method.Delete);
            request.AddHeader(API_KEY, _clientConfiguration.ApiKey);
            await _restClient.ExecuteAsync<ApiResult>(request);
        }
    }
}
