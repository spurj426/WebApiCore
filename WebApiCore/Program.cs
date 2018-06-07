using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebApiCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                // Security
                .UseKestrel(options => options.AddServerHeader = false) 
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
