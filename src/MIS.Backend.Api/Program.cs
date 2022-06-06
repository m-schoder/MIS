
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MIS.Backend.Api;

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
                webBuilder.UseStartup<Startup>();
            });
}