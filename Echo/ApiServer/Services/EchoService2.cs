using System;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;

namespace ApiServer
{
    public class EchoService2 : IEchoService
    {
        public string Echo(string s)
        {
            var orleansClient = new ClientBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "HelloWorldApp";
                })
                .ConfigureLogging(logging => logging.AddConsole())
                .Build();
            orleansClient.Connect().GetAwaiter().GetResult();
            var g = orleansClient.GetGrain<IEchoGrain>(System.Guid.NewGuid());
            return g.Echo(s).GetAwaiter().GetResult();
        }
    }
}
