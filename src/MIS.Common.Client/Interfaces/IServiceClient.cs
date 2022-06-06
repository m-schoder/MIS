using System.Threading.Tasks;
using JetBrains.Annotations;

namespace MIS.Common.Client.Interfaces
{
    [PublicAPI]
    public interface IServiceClient
    {
        Task ReloadConfiguration();
        Task<TResponse> Get<TResponse>(string resource) where TResponse : new();
        Task Post(string resource);
        Task Post<TBody>(string resource, TBody body) where TBody : class;
        Task<TResponse> Post<TResponse, TBody>(string resource, TBody body) where TResponse : new() where TBody : class;
        Task Put(string resource);
        Task<TResponse> Put<TResponse, TBody>(string resource, TBody body) where TResponse : new() where TBody : class;
        Task Delete(string resource);
    }
}