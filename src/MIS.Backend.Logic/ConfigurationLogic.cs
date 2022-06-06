using System.Collections.Generic;
using System.Threading.Tasks;
using MIS.Backend.DataAccess.Interfaces;
using MIS.Backend.Logic.Interfaces;
using MIS.Backend.Mappers.Interfaces;
using MIS.Common.DataTransferObjects.Configuration;
using ConfigurationValue = MIS.Backend.Models.ConfigurationValue;

namespace MIS.Backend.Logic;

public class ConfigurationLogic : IConfigurationLogic
{
    private readonly IRepository<ConfigurationValue> _configurationRepository;
    private readonly IMapper<IList<ConfigurationValue>, GetConfigurationValuesResponse> _getConfigurationValuesResponseMapper;
    private readonly IMapper<ConfigurationValue, GetConfigurationValueResponse> _getConfigurationValueResponseMapper;
    private readonly IMapper<CreateConfigurationValueRequest, ConfigurationValue> _createConfigurationValueRequestMapper;
    private readonly IMapper<ConfigurationValue, CreateConfigurationValueResponse> _createConfigurationValueResponseMapper;
    private readonly IMapper<UpdateConfigurationValueRequest, ConfigurationValue> _updateConfigurationValueRequestMapper;
    private readonly IMapper<ConfigurationValue, UpdateConfigurationValueResponse> _updateConfigurationValueResponseMapper;

    public ConfigurationLogic(
        IRepository<ConfigurationValue> configurationRepository,
        IMapper<IList<ConfigurationValue>, GetConfigurationValuesResponse> getConfigurationValuesResponseMapper,
        IMapper<ConfigurationValue, GetConfigurationValueResponse> getConfigurationValueResponseMapper,
        IMapper<CreateConfigurationValueRequest, ConfigurationValue> createConfigurationValueRequestMapper,
        IMapper<ConfigurationValue, CreateConfigurationValueResponse> createConfigurationValueResponseMapper,
        IMapper<UpdateConfigurationValueRequest, ConfigurationValue> updateConfigurationValueRequestMapper,
        IMapper<ConfigurationValue, UpdateConfigurationValueResponse> updateConfigurationValueResponseMapper)
    {
        _configurationRepository = configurationRepository;
        _getConfigurationValuesResponseMapper = getConfigurationValuesResponseMapper;
        _getConfigurationValueResponseMapper = getConfigurationValueResponseMapper;
        _createConfigurationValueRequestMapper = createConfigurationValueRequestMapper;
        _createConfigurationValueResponseMapper = createConfigurationValueResponseMapper;
        _updateConfigurationValueRequestMapper = updateConfigurationValueRequestMapper;
        _updateConfigurationValueResponseMapper = updateConfigurationValueResponseMapper;
    }

    public async Task<GetConfigurationValuesResponse> GetConfigurationValues()
    {
        var configurationValues = await _configurationRepository.GetAll();
        var response = _getConfigurationValuesResponseMapper.Map(configurationValues);
        return response;
    }

    public async Task<GetConfigurationValueResponse> GetConfigurationValue(string name)
    {
        var configurationValue = await _configurationRepository.Single(x => x.Name == name);
        var response = _getConfigurationValueResponseMapper.Map(configurationValue);
        return response;
    }

    public async Task<CreateConfigurationValueResponse> CreateConfigurationValue(CreateConfigurationValueRequest request)
    {
        var configurationValue = _createConfigurationValueRequestMapper.Map(request);
        configurationValue = await _configurationRepository.Create(configurationValue);
        var response = _createConfigurationValueResponseMapper.Map(configurationValue);
        return response;
    }

    public async Task<UpdateConfigurationValueResponse> UpdateConfigurationValue(string name, UpdateConfigurationValueRequest request)
    {
        var configurationValue = await _configurationRepository.Single(x => x.Name == name);
        if (configurationValue != null)
        {
            var idFromDb = configurationValue.Id;
            configurationValue = _updateConfigurationValueRequestMapper.Map(request);
            configurationValue.Id = idFromDb;
            configurationValue.Name = name;
        }
        await _configurationRepository.Update(configurationValue);
        var response = _updateConfigurationValueResponseMapper.Map(configurationValue);
        return response;
    }

    public async Task DeleteConfigurationValue(string name)
    {
        var configurationValue = await _configurationRepository.Single(x => x.Name == name);
        if (configurationValue != null)
        {
            await _configurationRepository.Remove(configurationValue);
        }
    }
}