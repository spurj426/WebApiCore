using Microsoft.Extensions.Configuration;

namespace WebApiCore.Settings.Infrastructure
{
    public class ConfigsHelper<T> where T : new()
    {
        private static T _config;

        public static T GetConfig(string outputPath, string section)
        {
            if (_config == null)
            {
                _config = new T();

                var iConfig = ConfigurationRoot.GetIConfigurationRoot(outputPath);

                iConfig.GetSection(section).Bind(_config);

            }
            return _config;
        }
    }
}
