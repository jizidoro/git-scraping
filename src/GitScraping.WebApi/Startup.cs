#region

using GitScraping.Application.Interfaces;
using GitScraping.Application.Services;
using GitScraping.Core.Helpers.Extensions;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Models;
using GitScraping.Infrastructure.Bases;
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
using Newtonsoft.Json;
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
                .AddSqlServer(Configuration)
                .AddEntityRepository(Configuration)
                .AddHealthChecks(Configuration)
                .AddAuthentication(Configuration)
                .AddVersioning()
                .AddSwagger()
                .AddUseCases()
                .AddCustomControllers()
                .AddCustomCors()
                .AddProxy()
                .AddCustomDataProtection();

            services.AddAutoMapperSetup();
            services.AddLogging();

            services.AddScoped(typeof(ILookupServiceApp<>), typeof(LookupServiceApp<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<HashingOptions>();
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