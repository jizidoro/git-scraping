#region

using GitScraping.Application.Interfaces;
using GitScraping.Application.Services;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.WebApi.Modules;
using GitScraping.WebApi.Modules.Common;
using GitScraping.WebApi.Modules.Common.FeatureFlags;
using GitScraping.WebApi.Modules.Common.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

#endregion

namespace GitScraping.UnitTests.Helpers
{
    public class ObterServiceProviderDb
    {
        public ServiceProvider Execute()
        {
            var services = new ServiceCollection();

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();

            services
                .AddFeatureFlags(configuration)
                .AddInvalidRequestLogging()
                .AddHealthChecks(configuration)
                .AddAuthentication(configuration)
                .AddVersioning()
                .AddSwagger()
                .AddUseCases()
                .AddCustomControllers()
                .AddCustomCors()
                .AddProxy()
                .AddCustomDataProtection();

            services.AddAutoMapperSetup();

            services.AddLogging();
            
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );

            // Create the service provider instance
            return services.BuildServiceProvider();
        }
    }
}