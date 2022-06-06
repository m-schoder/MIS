using System;
using System.Threading.Tasks;
using MIS.Backend.Logic.Interfaces;

namespace MIS.Backend.Logic
{
    public class ConfigurationProxy : PiModules.Interfaces.IConfigurationProxy
    {
        private readonly IConfigurationLogic _configurationLogic;

        public ConfigurationProxy(IConfigurationLogic configurationLogic)
        {
            _configurationLogic = configurationLogic;
        }

        public async Task<string> GetString(string name)
        {
            var value = await _configurationLogic.GetConfigurationValue(name);
            return value.Value;
        }

        public async Task<int> GetInt32(string name)
        {
            var value = await _configurationLogic.GetConfigurationValue(name);
            return Convert.ToInt32(value.Value);
        }
    }
}