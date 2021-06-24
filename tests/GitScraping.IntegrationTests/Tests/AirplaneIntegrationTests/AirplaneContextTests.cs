#region

using System.Threading.Tasks;
using GitScraping.Domain.Models;
using GitScraping.Infrastructure.DataAccess;
using GitScraping.Infrastructure.Repositories;
using GitScraping.UnitTests.Helpers;
using Microsoft.EntityFrameworkCore;
using Xunit;

#endregion

namespace GitScraping.IntegrationTests.Tests.AirplaneIntegrationTests
{
    public class AirplaneContextTests
    {
        [Fact]
        public async Task Airplane_Context()
        {
            var options = new DbContextOptionsBuilder<GitScrapingContext>()
                .UseInMemoryDatabase("test_database_return_Get_ReturnsAirplane")
                .Options;

            Airplane airplane = null;

            await using var context = new GitScrapingContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            var repository = new AirplaneRepository(context);
            airplane = await repository.GetById(1);
            Assert.NotNull(airplane);
        }
    }
}