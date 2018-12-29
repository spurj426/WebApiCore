using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MvcClient.Security.Config;

namespace MvcClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Leveraging built in NET CORE IoC for Configurations derived from appsettings
            var section = Configuration.GetSection("ContentSecurityPolicyConfig");
            services.Configure<ContentSecurityPolicyConfig>(section);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
        IOptions<ContentSecurityPolicyConfig> cspConfig)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Must be called before app.UseMvc();
            app.UseCors("AllowAllOrigins");

            // Security Headers
            var policyCollection = new HeaderPolicyCollection()         // NetEscapades.AspNetCore.SecurityHeaders
                .AddFrameOptionsSameOrigin()                            // prevent click-jacking
                .AddXssProtectionBlock()                                // prevent cross-site scripting (XSS)
                .AddContentTypeOptionsNoSniff()                         // prevent drive-by-downloads
                .AddCustomHeader("Content-Security-Policy", cspConfig.Value.CspString)
                .AddCustomHeader("X-Content-Security-Policy", cspConfig.Value.CspString);
            app.UseSecurityHeaders(policyCollection);                   // NetEscapades.AspNetCore.SecurityHeaders

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
