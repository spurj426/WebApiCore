using System.IO;
using Microsoft.Extensions.Configuration;

namespace WebApiCore.Common.Infrastructure
{
    public class ConnectionString
    {
        private static string _conn;

        public static string GetConfig(string name)
        {
            if (_conn == null)
            {
                _conn = string.Empty;

                var iConfig = ConfigurationRoot.GetIConfigurationRoot();

                _conn = iConfig.GetConnectionString(name);

            }
            return _conn;
        }
    }


    public class ConfigHelper<T> where T : new()
    {
        private static T _config;

        public static T GetConfig(string section)
        {
            if (_config == null)
            {
                _config = new T();
                var path = Directory.GetCurrentDirectory();
                var configuration = ConfigurationRoot.GetIConfigurationRoot(path);

                configuration.GetSection(section).Bind(_config);

            }
            return _config;
        }

        public static T GetConfig(string section, string outputPath)
        {
            if (_config == null)
            {
                _config = new T();

                var configuration = ConfigurationRoot.GetIConfigurationRoot(outputPath);

                configuration.GetSection(section).Bind(_config);

            }
            return _config;
        }
    }

    //public class ConfigHelper
    //{

    //    public static IConfiguration GetConfigSection(string section, string outputPath = null)
    //    {
    //        return ConfigurationRoot.GetIConfigurationRoot(outputPath).GetSection(section);
    //    }
    //}
}
