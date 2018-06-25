// https://weblog.west-wind.com/posts/2018/Feb/18/Accessing-Configuration-in-NET-Core-Test-Projects

using Microsoft.Extensions.Configuration;

namespace WebApiCore.Tests
{
    public class ConfigurationRoot
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets("")
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
