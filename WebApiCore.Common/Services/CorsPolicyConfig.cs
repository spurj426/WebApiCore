namespace WebApiCore.Config
{
    /// <summary>
    /// TODO: Make CORS policy configurable.  
    /// </summary>
    public class CorsPolicyConfig
    {
        public CorsPolicyConfig() { }

        public string AllowAllOrigins { get; set; } = "AllowAllOrigins";
    }
}
