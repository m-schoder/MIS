using System.Collections.Generic;
using AutoMapper;
using MIS.Common.DataTransferObjects.Configuration;
using ConfigurationValue = MIS.Backend.Models.ConfigurationValue;
using ConfigurationValueDto = MIS.Common.DataTransferObjects.Configuration.ConfigurationValue;

namespace MIS.Backend.Mappers
{
    public class GetConfigurationValuesResponseMapper : Mapper<IList<ConfigurationValue>, GetConfigurationValuesResponse>
    {
        public GetConfigurationValuesResponseMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ConfigurationValue, ConfigurationValueDto>();
                cfg.CreateMap<IList<ConfigurationValue>, GetConfigurationValuesResponse>()
                    .ForMember(d => d.ConfigurationValues, o => o.MapFrom(s => s));
            });
            _mapper = config.CreateMapper();
        }
    }
}