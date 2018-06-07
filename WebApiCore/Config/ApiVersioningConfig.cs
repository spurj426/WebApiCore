using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Config
{
    public class ApiVersioningConfig
    {
        public ApiVersioningConfig(){}

        public bool ReportApiVersions { get; set; }
        public bool AssumeDefaultVersionWhenUnspecified { get; set; }
        public int ApiMajorVersion { get; set; } = 1;
        public int ApiMinorVersion { get; set; } = 0;
        public ApiVersion DefaultApiVersion => new ApiVersion(ApiMajorVersion, ApiMinorVersion);
    }
}
