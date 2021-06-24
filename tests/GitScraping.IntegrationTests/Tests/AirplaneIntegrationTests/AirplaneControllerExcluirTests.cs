#region

using System.Threading.Tasks;
using GitScraping.Infrastructure.DataAccess;
using GitScraping.Infrastructure.Repositories;
using GitScraping.UnitTests.Helpers;
using GitScraping.UnitTests.Tests.AirplaneTests.Bases;
using Microsoft.EntityFrameworkCore;
using Xunit;

#endregion

namespace GitScraping.IntegrationTests.Tests.AirplaneIntegrationTests
{
    public class AirplaneControllerExcluirTests
    {
        private readonly AirplaneInjectionController _airplaneInjectionController = new();

        [Fact]
        public async Task AirplaneController_Excluir()
        {
            var options = new DbContextOptionsBuilder<GitScrapingContext>()
                .UseInMemoryDatabase("test_database_return_AirplaneController_Excluir")
                .Options;


            var idAirplane = 1;

            await using var context = new GitScrapingContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);

            var airplaneController = _airplaneInjectionController.ObterAirplaneController(context);
            _ = await airplaneController.Excluir(idAirplane);

            var repository = new AirplaneRepository(context);
            var airplane = await repository.GetById(1);
            Assert.Null(airplane);
        }
    }
}