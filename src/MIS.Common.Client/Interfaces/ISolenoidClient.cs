using System.Threading.Tasks;
using JetBrains.Annotations;
using MIS.Common.DataTransferObjects.Solenoid;

namespace MIS.Common.Client.Interfaces
{
    [PublicAPI]
    public interface ISolenoidClient
    {
        Task SwitchOn();
        Task SwitchOff();
        Task<GetStateResponse> GetState();
        Task<SayHelloResponse> SayHello();
    }
}