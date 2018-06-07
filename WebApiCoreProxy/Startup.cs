using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetEscapades.AspNetCore.SecurityHeaders;
using Newtonsoft.Json.Serialization;


namespace WebApiCoreProxy
{
    public class Startup
    {
        public static HttpClient JsonHttpClient = new HttpClient();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JsonHttpClient.BaseAddress = new Uri(ProxyConfig.WebApiCoreUrl);
            JsonHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // HttpContextAccessor services
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add framework services.
            services.AddMvc().AddJsonOptions(opt =>
            {
                if (opt.SerializerSettings.ContractResolver != null)
                {
                    var resolver = opt.SerializerSettings.ContractResolver as DefaultContractResolver;
                    resolver.NamingStrategy = new CamelCaseNamingStrategy();
                }
            }); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Security
            var policyCollection = new HeaderPolicyCollection()         // NetEscapades.AspNetCore.SecurityHeaders
                .AddFrameOptionsSameOrigin()                            // prevent click-jacking
                .AddXssProtectionBlock()                                // prevent cross-site scripting (XSS)
                .AddContentTypeOptionsNoSniff()                         // prevent drive-by-downloads
                .AddCustomHeader("Content-Security-Policy",             // add custom CSP
                    "default-src 'self'; style-src 'self'; font-src 'self'; script-src 'self'; " +
                    "img-src 'self'; 'unsafe-inline'; child-src 'none';");

            app.UseSecurityHeaders(policyCollection);           // NetEscapades.AspNetCore.SecurityHeaders

            app.UseMvc();
        }
    }
}
