namespace MvcClient.Security.Config
{
    public class ContentSecurityPolicyConfig
    {
        public ContentSecurityPolicyConfig() { }

        public string CspString { get; set; } = @"default-src 'self'; style-src 'self'; font-src 'self'; script-src 'self'; img-src 'self'; 'unsafe-inline'; child-src 'none';";
    }
}
