using Microsoft.Extensions.Configuration;

namespace WebApiCore.Tests
{
    public class TestsConfig
    {
        private static IConfigurationRoot _configRoot = null;

        public static string ValuesServiceMapperImpl => GetConfig()["ValuesServiceConfig:0:ValuesServiceClientImpl"];

        public static string ValuesJsonDataSource => GetConfig()["ValuesServiceConfig:0:ValuesJsonDataSource"];

        public static string ValuesXmlDataSource => GetConfig()["ValuesServiceConfig:0:ValuesXmlDataSource"];

        public static string ValuesTextDataSource => GetConfig()["ValuesServiceConfig:0:ValuesTextDataSource"];

        private static IConfigurationRoot GetConfig()
        {
            return _configRoot ?? (_configRoot = new ConfigurationBuilder()
                       .AddJsonFile("tests-config.json")
                       .Build());
        }
    }
}
