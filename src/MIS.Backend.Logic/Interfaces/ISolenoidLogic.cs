using System.Threading.Tasks;
using MIS.Common.DataTransferObjects.Solenoid;
using GetStateResponse = MIS.Common.DataTransferObjects.Solenoid.GetStateResponse;

namespace MIS.Backend.Logic.Interfaces;

public interface ISolenoidLogic : ILogic
{
    Task SwitchOn();
    Task SwitchOff();
    Task<GetStateResponse> GetState();
    Task<SayHelloResponse> SayHello();
}