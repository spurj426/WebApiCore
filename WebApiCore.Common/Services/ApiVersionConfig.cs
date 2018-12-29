using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Config
{
    public class ApiVersionConfig
    {
        public bool ReportApiVersions { get; set; }
        public bool AssumeDefaultVersionWhenUnspecified { get; set; }
        public int MajorVersion { get; set; } = 1;
        public int MinorVersion { get; set; } = 0;
        public ApiVersion DefaultApiVersion => new ApiVersion(MajorVersion, MinorVersion);
    }
}