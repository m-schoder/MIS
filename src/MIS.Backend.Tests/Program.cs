using System;
using System.Threading.Tasks;
using MIS.Common.Client;
using MIS.Common.Client.Interfaces;
using MIS.Common.DataTransferObjects.Configuration;
using static MIS.Common.Constants.Constants;

namespace MIS.Backend.Tests;

internal class Program
{
    private static async Task Main()
    {
        var clientConfig = new ClientConfiguration();
        var serviceClient = new ServiceClient(clientConfig);
        //await TestSolenoid(serviceClient);
        await TestConfiguration(serviceClient);
        await CheckMiddlewareHostAddress(serviceClient);
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    private static async Task CheckMiddlewareHostAddress(ServiceClient serviceClient)
    {
        var configClient = new ConfigurationClient(serviceClient);
        var configValue = await configClient.GetConfigurationValue(MIDDLEWARE_HOST_ADDRESS);
        if (configValue != null)
        {
            Console.WriteLine($"{configValue.Id} : {configValue.Name} : {configValue.Value}");
        }
    }

    private static async Task TestConfiguration(ServiceClient serviceClient)
    {
        var configClient = new ConfigurationClient(serviceClient);
        var configValueName = "TestConfigurationValue";
        var initialValue = "InitialValue";
        var createRequest = new CreateConfigurationValueRequest()
        {
            Name = configValueName,
            Value = initialValue
        };
        await configClient.CreateConfigurationValue(createRequest);
        var configValue = await configClient.GetConfigurationValue(configValueName);
        Console.WriteLine("Created Config Value:");
        Console.WriteLine($"{configValue.Id} : {configValue.Name} : {configValue.Value}");

        var request = new UpdateConfigurationValueRequest
        {
            Value = "Modified"
        };
        Console.WriteLine("Updating to new Config Value");
        await configClient.UpdateConfigurationValue(configValueName, request);
        configValue = await configClient.GetConfigurationValue(configValueName);
        Console.WriteLine($"{configValue.Id} : {configValue.Name} : {configValue.Value}");


        request = new UpdateConfigurationValueRequest
        {
            Value = initialValue
        };
        Console.WriteLine("Reverting to initial Config Value");
        await configClient.UpdateConfigurationValue(configValueName, request);
        configValue = await configClient.GetConfigurationValue(configValueName);
        Console.WriteLine($"{configValue.Id} : {configValue.Name} : {configValue.Value}");

        Console.WriteLine("Deleting Config Value");
        await configClient.DeleteConfigurationValue(configValueName);
        
        Console.WriteLine("Printing all values as proof of deletion");
        foreach (var v in configClient.GetConfigurationValues().Result.ConfigurationValues)
        {
            Console.WriteLine($"{v.Id} : {v.Name} : {v.Value}");
        }
    }

    public static async Task TestSolenoid(ServiceClient serviceClient)
    {
        var solenoidClient = new SolenoidClient(serviceClient);
        await solenoidClient.SwitchOn();
        var isSolenoidOn = await solenoidClient.GetState();
        Console.WriteLine($"{isSolenoidOn.SolenoidState}");
        await Task.Delay(500);
        await solenoidClient.SwitchOff();
        isSolenoidOn = await solenoidClient.GetState();
        Console.WriteLine($"{isSolenoidOn.SolenoidState}");
    }
}

public class ClientConfiguration : IClientConfiguration
{
    public string ServiceBaseUrl { get; set; } = "";
    public string ApiKey { get; set; } = "";
}