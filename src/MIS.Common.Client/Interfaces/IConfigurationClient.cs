using System.Threading.Tasks;
using MIS.Common.DataTransferObjects.Configuration;

namespace MIS.Common.Client.Interfaces
{
    public interface IConfigurationClient
    {
        Task<GetConfigurationValueResponse> GetConfigurationValue(string name);
        Task<GetConfigurationValuesResponse> GetConfigurationValues();
        Task<CreateConfigurationValueResponse> CreateConfigurationValue(CreateConfigurationValueRequest request);
        Task<UpdateConfigurationValueResponse> UpdateConfigurationValue(string name, UpdateConfigurationValueRequest request);
        Task DeleteConfigurationValue(string name);
    }
}