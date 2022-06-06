using AutoMapper;
using MIS.Common.DataTransferObjects.Configuration;
using ConfigurationValue = MIS.Backend.Models.ConfigurationValue;

namespace MIS.Backend.Mappers;

public class GetConfigurationValueResponseMapper : Mapper<ConfigurationValue, GetConfigurationValueResponse>
{
    public GetConfigurationValueResponseMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ConfigurationValue, GetConfigurationValueResponse>();
        });
        _mapper = config.CreateMapper();
    }
}