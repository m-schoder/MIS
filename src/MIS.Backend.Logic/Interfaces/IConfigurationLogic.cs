using System.Threading.Tasks;
using MIS.Common.DataTransferObjects.Configuration;

namespace MIS.Backend.Logic.Interfaces;

public interface IConfigurationLogic : ILogic
{
    Task<GetConfigurationValuesResponse> GetConfigurationValues();

    Task<GetConfigurationValueResponse> GetConfigurationValue(string name);

    Task<CreateConfigurationValueResponse> CreateConfigurationValue(CreateConfigurationValueRequest request);
        
    Task<UpdateConfigurationValueResponse> UpdateConfigurationValue(string name, UpdateConfigurationValueRequest request);
        
    Task DeleteConfigurationValue(string name);
}