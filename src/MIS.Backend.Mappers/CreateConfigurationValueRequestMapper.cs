using AutoMapper;
using MIS.Common.DataTransferObjects.Configuration;
using ConfigurationValue = MIS.Backend.Models.ConfigurationValue;

namespace MIS.Backend.Mappers;

public class CreateConfigurationValueRequestMapper : Mapper<CreateConfigurationValueRequest, ConfigurationValue>
{
    public CreateConfigurationValueRequestMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CreateConfigurationValueRequest, ConfigurationValue>();
        });
        _mapper = config.CreateMapper();
    }
}