#region

using GitScraping.Infrastructure.DataAccess;
using GitScraping.UnitTests.Helpers;
using GitScraping.WebApi.UseCases.V1.AirplaneApi;
using Microsoft.Extensions.Logging;
using Moq;

#endregion

namespace GitScraping.UnitTests.Tests.AirplaneTests.Bases
{
    public class AirplaneInjectionController
    {
        private readonly AirplaneInjectionAppService _airplaneInjectionAppService = new();

        public AirplaneController ObterAirplaneController(GitScrapingContext context)
        {
            var mapper = MapperHelper.ConfigMapper();

            var logger = Mock.Of<ILogger<AirplaneController>>();

            var airplaneAppService = _airplaneInjectionAppService.ObterAirplaneAppService(context, mapper);

            return new AirplaneController(airplaneAppService, mapper, logger);
        }
    }
}