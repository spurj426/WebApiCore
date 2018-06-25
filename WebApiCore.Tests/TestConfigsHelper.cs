using Microsoft.Extensions.Configuration;
using WebApiCore.Services.Config;

namespace WebApiCore.Tests
{
    public class TestConfigsHelper
    {
        private static ValuesServiceConfig valuesServiceConfig;

        public static ValuesServiceConfig GetValuesServiceConfig(string outputPath)
        {
            if (valuesServiceConfig == null)
            {
                valuesServiceConfig = new ValuesServiceConfig();
                var iConfig = ConfigurationRoot.GetIConfigurationRoot(outputPath);

                iConfig.GetSection("ValuesServiceConfig")
                    .Bind(valuesServiceConfig);
            }

            return valuesServiceConfig;
        }
    }
}
