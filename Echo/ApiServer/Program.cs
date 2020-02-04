using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Hosting;
using Orleans.Configuration;
using System.Threading.Tasks;

namespace ApiServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.WhenAny(
                Task.Run(() => StartWebHost()),
                Task.Run(() => StartSiloHost())).GetAwaiter().GetResult();
        }

        //

        private static void StartWebHost()
        {
            var webHost = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .Build();
            webHost.Run();
        }

        private static void StartSiloHost()
        {
            var siloHost = new SiloHostBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "HelloWorldApp";
                })
                .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback)
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(EchoGrain).Assembly).WithReferences())
                .ConfigureLogging(logging => logging.AddConsole())
                .Build();
            siloHost.StartAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            siloHost.Stopped.ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
