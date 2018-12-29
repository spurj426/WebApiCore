// https://weblog.west-wind.com/posts/2018/Feb/18/Accessing-Configuration-in-NET-Core-Test-Projects
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace WebApiCore.Common.Infrastructure
{
    public class ConfigurationRoot
    {
        public static IConfigurationRoot GetIConfigurationRoot(IHostingEnvironment env)
        {
            return new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                // .AddUserSecrets("")
                .AddEnvironmentVariables()
                .Build();
        }

        public static IConfigurationRoot GetIConfigurationRoot(string outputPath = null)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                // .AddUserSecrets("")
                .AddEnvironmentVariables()
                .Build();
        }       
    }
}
