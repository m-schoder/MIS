using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using MIS.Common.Protobuf;

namespace MIS.Middleware.Tests;

internal class Program
{
    private static async Task Main()
    {
        var channel = GrpcChannel.ForAddress("http://192.168.178.29:5050");
        var client = new IrrigationSystemService.IrrigationSystemServiceClient(channel);
        var request = new HelloRequest
        {
            Name = "Michael"
        };
        var response = await client.SayHelloAsync(request);
        Console.WriteLine($"{response.Message}");
        var request2 = new GetStateRequest();
        var response2 = await client.GetStateAsync(request2);
        Console.WriteLine($"{response2.IsSolenoidOn}");
        Console.WriteLine(GetPublicIPv4Address());
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

    }

    public static string GetPublicIPv4Address() => new System.Net.Http.HttpClient()
        .GetStringAsync("https://ipinfo.io/ip").GetAwaiter().GetResult().Replace("\n", "");
}