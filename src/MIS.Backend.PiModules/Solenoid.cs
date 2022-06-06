using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using MIS.Backend.PiModules.Interfaces;
using MIS.Common.Protobuf;
using static MIS.Common.Constants.Constants;
using static MIS.Backend.PiModules.Constants.Constants;

namespace MIS.Backend.PiModules;

public class Solenoid : ISolenoid
{
    private readonly IConfigurationProxy _configurationProxy;
    private string _middlewareHostAddress;

    public Solenoid(IConfigurationProxy configurationProxy)
    {
        _configurationProxy = configurationProxy;
    }

    public async Task SwitchOn()
    {
        await ReadConfiguration();
        var channel = GrpcChannel.ForAddress(_middlewareHostAddress, new GrpcChannelOptions{ HttpHandler = ConstantHttpHandler });
        var client = new IrrigationSystemService.IrrigationSystemServiceClient(channel);
        var request = new SwitchOnRequest();
        await client.SwitchOnAsync(request);
    }
    public async Task SwitchOff()
    {
        await ReadConfiguration();
        var channel = GrpcChannel.ForAddress(_middlewareHostAddress, new GrpcChannelOptions { HttpHandler = ConstantHttpHandler });
        var client = new IrrigationSystemService.IrrigationSystemServiceClient(channel);
        var request = new SwitchOffRequest();
        await client.SwitchOffAsync(request);
    }

    public async Task<bool> GetState()
    {
        await ReadConfiguration();
        var channel = GrpcChannel.ForAddress(_middlewareHostAddress, new GrpcChannelOptions { HttpHandler = ConstantHttpHandler });
        var client = new IrrigationSystemService.IrrigationSystemServiceClient(channel);
        var request = new GetStateRequest();
        return (await client.GetStateAsync(request)).IsSolenoidOn;
    }

    public async Task<string> SayHello()
    {
        await ReadConfiguration();
        var channel = GrpcChannel.ForAddress(_middlewareHostAddress, new GrpcChannelOptions { HttpHandler = ConstantHttpHandler });
        var client = new IrrigationSystemService.IrrigationSystemServiceClient(channel);
        var request = new HelloRequest { Name = Environment.MachineName };
        return (await client.SayHelloAsync(request)).Message;
    }

    private async Task ReadConfiguration()
    {
        _middlewareHostAddress = await _configurationProxy.GetString(MIDDLEWARE_HOST_ADDRESS);
    }
}