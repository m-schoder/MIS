using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MIS.Middleware.Processor;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSystemd()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseKestrel();
                webBuilder.ConfigureKestrel((_, options) =>
                {
                    var config = (IConfiguration)options.ApplicationServices.GetService(typeof(IConfiguration));
                    if (config == null) return;
                    var cert = new X509Certificate2(config["Certificate:Path"]);
                    options.ListenAnyIP(5050, listenOptions =>
                    {
                        listenOptions.UseHttps(cert, httpsOptions =>
                        {
                            httpsOptions.SslProtocols = SslProtocols.Tls12;
                            httpsOptions.ClientCertificateMode = ClientCertificateMode.NoCertificate;
                        });
                    });
                });
                webBuilder.UseStartup<Startup>();
            });
}