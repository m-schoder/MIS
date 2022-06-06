using System.Threading.Tasks;
using MIS.Backend.Logic.Interfaces;
using MIS.Backend.PiModules.Interfaces;
using MIS.Common.DataTransferObjects.Enums;
using MIS.Common.DataTransferObjects.Solenoid;

namespace MIS.Backend.Logic;

public class SolenoidLogic : ISolenoidLogic
{
    private readonly ISolenoid _solenoid;

    public SolenoidLogic(ISolenoid solenoid)
    {
        _solenoid = solenoid;
    }

    public async Task SwitchOn()
    {
        await _solenoid.SwitchOn();
    }

    public async Task SwitchOff()
    {
        await _solenoid.SwitchOff();
    }

    public async Task<GetStateResponse> GetState()
    {
        var isSolenoidOn = await _solenoid.GetState();
        return new GetStateResponse
        {
            SolenoidState = isSolenoidOn ? SolenoidState.SwitchedOn : SolenoidState.SwitchedOff
        };
    }

    public async Task<SayHelloResponse> SayHello()
    {
        var response = await _solenoid.SayHello();
        return new SayHelloResponse
        {
            Message = response
        };
    }
}