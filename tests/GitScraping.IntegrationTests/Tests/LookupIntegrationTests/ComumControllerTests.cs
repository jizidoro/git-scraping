#region

using System.Threading.Tasks;
using GitScraping.Application.Bases;
using GitScraping.Infrastructure.DataAccess;
using GitScraping.UnitTests.Helpers;
using GitScraping.UnitTests.Tests.UsuarioSistemaTests.Bases;
using GitScraping.WebApi.UseCases.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace GitScraping.IntegrationTests.Tests.LookupIntegrationTests
{
    public sealed class ComumControllerTests
    {
        private readonly ObterServiceProviderDb _obterServiceProviderDb = new();
        private readonly ObterServiceProviderMemDb _obterServiceProviderMemDb = new();
        private readonly ITestOutputHelper _output;
        private readonly UsuarioSistemaInjectionAppService _usuarioSistemaInjectionAppService = new();

        public ComumControllerTests(ITestOutputHelper output)
        {
            _output = output;
        }


        private ComumController ObterComumControllerDb()
        {
            var mapper = MapperHelper.ConfigMapper();

            var serviceProvider = _obterServiceProviderDb.Execute();

            var context = serviceProvider.GetService<GitScrapingContext>();

            var baUsuAppService = _usuarioSistemaInjectionAppService.ObterUsuarioSistemaAppService(context, mapper);

            return new ComumController(serviceProvider, baUsuAppService);
        }

        private ComumController ObterComumControllerMemDb()
        {
            var mapper = MapperHelper.ConfigMapper();

            var serviceProvider = _obterServiceProviderMemDb.Execute();

            var context = serviceProvider.GetService<GitScrapingContext>();

            var baUsuAppService = _usuarioSistemaInjectionAppService.ObterUsuarioSistemaAppService(context, mapper);

            return new ComumController(serviceProvider, baUsuAppService);
        }

        [Fact(Skip = "usa a instancia local do sqlserver")]
        public async Task GetLookupUsuarioSistemaDb_Test()
        {
            var comumController = ObterComumControllerDb();
            var result = await comumController.GetLookupUsuarioSistema();

            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as ListResultDto<LookupDto>;
                Assert.NotNull(actualResultValue);
            }
        }

        [Fact]
        public async Task GetLookupUsuarioSistemaMemDb_Test()
        {
            var comumController = ObterComumControllerMemDb();
            var result = await comumController.GetLookupUsuarioSistema();

            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as ListResultDto<LookupDto>;
                Assert.NotNull(actualResultValue);
            }
        }
    }
}