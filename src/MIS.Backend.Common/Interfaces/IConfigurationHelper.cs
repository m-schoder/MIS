namespace MIS.Backend.Common.Interfaces
{
    public interface IConfigurationHelper
    {
        string ConnectionString { get; set; }
        string ApiKey { get; set; }
    }
}