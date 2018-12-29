using Microsoft.Extensions.Options;

namespace WebApiCore.Common.Config
{
    /// <summary>
    /// Returns configurations for the ValuesService. These values are set in the appsettings.json file.
    /// </summary>
    public class ValuesServiceConfig
    {
        public ValuesServiceMapper Mapper { get; set; } = ValuesServiceMapper.Json;
        public ValuesServiceProvider Provider { get; set; } = ValuesServiceProvider.FileSystem;
        public string DataSource { get; set; } = string.Empty;
    }

    public enum ValuesServiceMapper
    {
        Json,
        Xml
    }

    public enum ValuesServiceProvider
    {
        FileSystem,
        Http
    }
}
