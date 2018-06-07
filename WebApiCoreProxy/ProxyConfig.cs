using Microsoft.Extensions.Configuration;

namespace WebApiCoreProxy
{
    public class ProxyConfig
    {
        private static IConfigurationRoot _configRoot = null;

        public static string WebApiCoreUrl => GetConfig()["WebApiCoreUrl"];

        private static IConfigurationRoot GetConfig()
        {
            return _configRoot ?? (_configRoot = new ConfigurationBuilder()
                       .AddJsonFile("proxy-config.json")
                       .Build());
        }
    }
}
