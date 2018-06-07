namespace WebApiCore.Services.Config
{
    public class ValuesServiceConfig
    {
        public ValuesServiceConfig() { }
        public ValuesServiceMapper Mapper { get; set; } = ValuesServiceMapper.Json;
        public ValuesServiceProvider Provider { get; set; } = ValuesServiceProvider.FileSystem;
        public string FileSystemDataSource { get; set; } = @"C:\Workspace\WebApiCore\WebApiCore\MockData\Values.json";
        public string Uri { get; set; } = string.Empty;
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
