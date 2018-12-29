using System.IO;
using Microsoft.Extensions.Configuration;

namespace WebApiCore.Data.Config
{
    public class ConfigHelper
    {
        private static string _connectionString;
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = GetIConfigurationRoot()["ConnectionString"];
                }
                return _connectionString;
            }
        }

        private static IConfigurationRoot GetIConfigurationRoot()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.AddUserSecrets("")
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
