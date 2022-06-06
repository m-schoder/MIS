using AutoMapper;
using MIS.Common.DataTransferObjects.Configuration;
using ConfigurationValue = MIS.Backend.Models.ConfigurationValue;

namespace MIS.Backend.Mappers;

public class UpdateConfigurationValueRequestMapper : Mapper<UpdateConfigurationValueRequest, ConfigurationValue>
{
    public UpdateConfigurationValueRequestMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UpdateConfigurationValueRequest, ConfigurationValue>();
        });
        _mapper = config.CreateMapper();
    }
}