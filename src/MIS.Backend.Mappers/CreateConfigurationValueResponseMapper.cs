using AutoMapper;
using MIS.Common.DataTransferObjects.Configuration;
using ConfigurationValue = MIS.Backend.Models.ConfigurationValue;

namespace MIS.Backend.Mappers;

public class CreateConfigurationValueResponseMapper : Mapper<ConfigurationValue, CreateConfigurationValueResponse>
{
    public CreateConfigurationValueResponseMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ConfigurationValue, CreateConfigurationValueResponse>();
        });
        _mapper = config.CreateMapper();
    }
}