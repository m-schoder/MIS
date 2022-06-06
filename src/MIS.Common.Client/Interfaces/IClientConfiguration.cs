namespace MIS.Common.Client.Interfaces
{
    public interface IClientConfiguration
    {
        string ServiceBaseUrl { get; set; }
        string ApiKey { get; set; }
    }
}