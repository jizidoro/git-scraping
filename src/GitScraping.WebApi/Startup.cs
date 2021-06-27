#region

using GitScraping.WebApi.Modules;
using GitScraping.WebApi.Modules.Common;
using GitScraping.WebApi.Modules.Common.FeatureFlags;
using GitScraping.WebApi.Modules.Common.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prometheus;
using Serilog;

#endregion

namespace GitScraping.WebApi
{
    /// <summary>
    ///     Startup.
    /// </summary>
    public sealed class Startup
    {
        /// <summary>
        ///     Startup constructor.
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        /// <summary>
        ///     Configure dependencies from application.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddFeatureFlags(Configuration)
                .AddInvalidRequestLogging()
                .AddHealthChecks(Configuration)
                .AddAuthentication(Configuration)
                .AddVersioning()
                .AddSwagger()
                .AddUseCases()
                .AddCustomControllers()
                .AddCustomCors()
                .AddProxy();

            services.AddAutoMapperSetup();
            services.AddLogging();
        }

        /// <summary>
        ///     Configure http request pipeline.
        /// </summary>
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/api/V1/CustomError")
                    .UseHsts();

            app
                .UseProxy(Configuration)
                .UseHealthChecks()
                .UseCustomCors()
                .UseCustomHttpMetrics()
                .UseRouting()
                .UseVersionedSwagger(provider, Configuration, env)
                .UseAuthentication()
                .UseAuthorization()
                .UseSerilogRequestLogging()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapMetrics();
                });
        }
    }
}