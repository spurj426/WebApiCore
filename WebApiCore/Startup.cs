using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApiCore.Config;
using WebApiCore.Interfaces;
using WebApiCore.Services;
using WebApiCore.Services.Config;
using WebApiCore.Services.Factory;

namespace WebApiCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // Autofac support
        public IContainer ApplicationContainer { get; set; }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Autofac support:  void changed to IServiceProvider.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            // Leveraging built in NET CORE IoC for Configurations derived from appsettings
            var versioningConfigSection = Configuration.GetSection("ApiVersioningConfig");
            services.Configure<ApiVersioningConfig>(versioningConfigSection);

            var valuesConfigSection = Configuration.GetSection("ValuesServiceConfig");
            services.Configure<ValuesServiceConfig>(valuesConfigSection);
            

            services.AddLogging();
            //services.AddMemoryCache();
            //services.AddDistributedMemoryCache();

            services.AddApiVersioning(v =>
            {
                v.ReportApiVersions = true;
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // Note:  Internet Explorer doesn't consider the port when comparing origins.  Test with Chrome.
            services.AddCors(options =>
            {
                // CORS headers are only sent on cross domain requests.
                // If you're going to test CORS operation the only effective way to
                // do is is by using a cross-site origin to trigger the CORS behavior. 
                // https://weblog.west-wind.com/posts/2016/Sep/26/ASPNET-Core-and-CORS-Gotchas
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
                // Additional policies go here...
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://example.com", "http://www.contoso.com");
                    });
            });

            // Add framework services.
            services.AddMvc();

            
            // Configure Containers (Please in this order)
            // This is used only to select provider (Client) at runtime or via configuration.
            services.AddSingleton<IClientFactory, ClientFactory>();
            services.AddSingleton<IValuesService, ValuesService>();

            //// Autofac support: Create the container builder
            //var builder = new ContainerBuilder();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Must be called before app.UseMvc();
            app.UseCors("AllowAllOrigins");

            app.UseMvc();
        }
    }
}
