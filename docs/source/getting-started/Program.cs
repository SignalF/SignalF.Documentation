using System.Runtime.Versioning;
using SignalF.Extensions.Controller;

namespace TestController;

[SupportedOSPlatform("linux")]
[SupportedOSPlatform("windows")]
public class Program
{
    public static async Task Main(string[] args)
    {

        var hostBuilder = Host.CreateDefaultBuilder(args)
            .UseSignalFController()
            .ConfigureServices(services =>
            {
                services.AddSignalFControllerService();
            });

        var host = hostBuilder.Build();

        await host.RunAsync();
    }
}
