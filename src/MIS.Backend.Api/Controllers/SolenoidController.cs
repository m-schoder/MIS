using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MIS.Backend.Api.Common;
using MIS.Backend.Logic.Interfaces;

namespace MIS.Backend.Api.Controllers;

[ApiController]
[Route("solenoid")]
public class SolenoidController : ApiController<ISolenoidLogic>
{
    public SolenoidController(
        ISolenoidLogic solenoidLogic,
        ILogger<ISolenoidLogic> logger) : base(solenoidLogic, logger) { }

    [HttpPost("on")]
    public Task<IActionResult> SwitchOn()
    {
        return Execute(l => l.SwitchOn());
    }

    [HttpPost("off")]
    public Task<IActionResult> SwitchOff()
    {
        return Execute(l => l.SwitchOff());
    }

    [HttpGet("state")]
    public Task<IActionResult> GetState()
    {
        return Execute(l => l.GetState());
    }

    [HttpGet("hello")]
    public Task<IActionResult> SayHello()
    {
        return Execute(l => l.SayHello());
    }
}