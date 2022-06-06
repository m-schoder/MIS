using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MIS.Backend.Api.Common;
using MIS.Backend.Logic.Interfaces;
using MIS.Common.DataTransferObjects.Configuration;

namespace MIS.Backend.Api.Controllers;

[Route("config")]
[ApiController]
public class ConfigurationController : ApiController<IConfigurationLogic>
{
    public ConfigurationController(
        IConfigurationLogic configurationLogic,
        ILogger<IConfigurationLogic> logger) : base(configurationLogic, logger) { }

    [HttpGet("{name}")]
    public Task<IActionResult> GetConfigurationValue(string name)
    {
        return Execute(x => x.GetConfigurationValue(name));
    }

    [HttpGet]
    public Task<IActionResult> GetConfigurationValues()
    {
        return Execute(x => x.GetConfigurationValues());
    }

    [HttpPost]
    public Task<IActionResult> CreateConfigurationValue(CreateConfigurationValueRequest request)
    {
        return Execute(x => x.CreateConfigurationValue(request));
    }

    [HttpPut("{name}")]
    public Task<IActionResult> UpdateConfigurationValue(string name, UpdateConfigurationValueRequest request)
    {
        return Execute(x => x.UpdateConfigurationValue(name, request));
    }

    [HttpDelete("{name}")]
    public Task<IActionResult> DeleteConfigurationValue(string name)
    {
        return Execute(x => x.DeleteConfigurationValue(name));
    }
}