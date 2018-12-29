using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApiCore.Common.Config;
using WebApiCore.Config;
using WebApiCore.Data.Repositories;
using WebApiCore.Services;
using WebApiCore.Services.Providers;

namespace WebApiCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Configuration = Common.Infrastructure.ConfigurationRoot.GetIConfigurationRoot(env);
        }

        // Autofac support
        public IContainer ApplicationContainer { get; set; }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Autofac support:  void changed to IServiceProvider.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            // Does not work with IOptions IoC
            //var valuesConfig = Common.Infrastructure.ConfigHelper<ValuesServiceConfig>.GetConfig("ValuesServiceConfig");
            //services.AddSingleton(valuesConfig);

            // Works with IOptions IoC
            var valuesConfigSection = Configuration.GetSection("ValuesServiceConfig");
            services.Configure<ValuesServiceConfig>(valuesConfigSection);

            services.AddLogging(builder =>
            {
                builder.AddConfiguration(Configuration.GetSection("Logging"))
                    .AddConsole()
                    .AddDebug();
            });
            //services.AddMemoryCache();
            //services.AddDistributedMemoryCache();

            var apiVersionConfig = Common.Infrastructure.ConfigHelper<ApiVersionConfig>.GetConfig("ApiVersionConfig");
            services.AddApiVersioning(v =>
            {
                v.ReportApiVersions = apiVersionConfig.ReportApiVersions;
                v.AssumeDefaultVersionWhenUnspecified = apiVersionConfig.AssumeDefaultVersionWhenUnspecified;
                v.DefaultApiVersion = apiVersionConfig.DefaultApiVersion;
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
            services.AddTransient<IFileSystemProvider, FileSystemProvider>();
            services.AddTransient<IValuesService, ValuesService>();
            services.AddSingleton<IValuesRepository, ValuesRepository>();

            /// Autofac support: Create the container builder
            //var builder = new ContainerBuilder();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env /*, ILoggerFactory loggerFactory */)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Must be called before app.UseMvc();
            app.UseCors("AllowAllOrigins");

            app.UseMvc();
        }
    }
}
