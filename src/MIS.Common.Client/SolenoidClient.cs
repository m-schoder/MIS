using System.Threading.Tasks;
using MIS.Common.Client.Interfaces;
using MIS.Common.DataTransferObjects.Solenoid;

namespace MIS.Common.Client
{
    public class SolenoidClient : ISolenoidClient
    {
        private readonly IServiceClient _serviceClient;

        public SolenoidClient(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }
        public async Task SwitchOn()
        {
            await _serviceClient.Post("solenoid/on");
        }
        public async Task SwitchOff()
        {
            await _serviceClient.Post("solenoid/off");
        }
        public Task<GetStateResponse> GetState()
        {
            return _serviceClient.Get<GetStateResponse>("solenoid/state");
        }
        public Task<SayHelloResponse> SayHello()
        {
            return _serviceClient.Get<SayHelloResponse>("solenoid/hello");
        }
    }
}