using System;

namespace MIS.Common.DataTransferObjects.Configuration
{
    public class GetConfigurationValueResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}