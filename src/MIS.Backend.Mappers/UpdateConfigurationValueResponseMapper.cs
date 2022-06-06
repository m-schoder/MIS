using AutoMapper;
using MIS.Common.DataTransferObjects.Configuration;
using ConfigurationValue = MIS.Backend.Models.ConfigurationValue;

namespace MIS.Backend.Mappers;

public class UpdateConfigurationValueResponseMapper : Mapper<ConfigurationValue, UpdateConfigurationValueResponse>
{
    public UpdateConfigurationValueResponseMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ConfigurationValue, UpdateConfigurationValueResponse>();
        });
        _mapper = config.CreateMapper();
    }
}