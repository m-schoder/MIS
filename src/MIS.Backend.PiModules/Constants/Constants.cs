using System.Net.Http;

namespace MIS.Backend.PiModules.Constants
{
    public static class Constants
    {
        public static HttpClientHandler ConstantHttpHandler { get; } = new()
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
    }
}
