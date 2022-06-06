using System.Threading.Tasks;
using Grpc.Core;
using MIS.Common.Protobuf;
using MIS.Middleware.Processor.Services.Interfaces;

namespace MIS.Middleware.Processor.Services;

public class GrpcService : IrrigationSystemService.IrrigationSystemServiceBase
{
    private readonly IGpioService _gpioService;

    public GrpcService(IGpioService gpioService)
    {
        _gpioService = gpioService;
    }

    public override async Task<SwitchOnResponse> SwitchOn(SwitchOnRequest request, ServerCallContext context)
    {
        await _gpioService.Initialize();
        await _gpioService.SwitchSolenoidOn();
        return new SwitchOnResponse();
    }

    public override async Task<SwitchOffResponse> SwitchOff(SwitchOffRequest request, ServerCallContext context)
    {
        await _gpioService.Initialize();
        await _gpioService.SwitchSolenoidOff();
        return new SwitchOffResponse();
    }

    public override async Task<GetStateResponse> GetState(GetStateRequest request, ServerCallContext context)
    {
        await _gpioService.Initialize();
        var isSolenoidOn = await _gpioService.IsSolenoidOn();
        return new GetStateResponse
        {
            IsSolenoidOn = isSolenoidOn,
        };
    }

    public override async Task<HelloResponse> SayHello(HelloRequest request, ServerCallContext context)
    {
        await _gpioService.Initialize();
        await _gpioService.SayHello();
        return new HelloResponse()
        {
            Message = "Hello " + request.Name
        };
    }
}