#region

using GitScraping.WebApi.Modules;
using GitScraping.WebApi.Modules.Common;
using GitScraping.WebApi.Modules.Common.FeatureFlags;
using GitScraping.WebApi.Modules.Common.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace GitScraping.UnitTests.Helpers
{
    public class getServiceProviderDb
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
                .AddProxy();

            services.AddAutoMapperSetup();

            services.AddLogging();

            return services.BuildServiceProvider();
        }
    }
}