#region

using System.Threading.Tasks;
using GitScraping.Application.Services;
using GitScraping.UnitTests.Helpers;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace GitScraping.UnitTests.Tests
{
    public sealed class EsquecerSenhaUsecaseTests
    {
        private readonly ITestOutputHelper _output;

        public EsquecerSenhaUsecaseTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task Test_EsquecerSenhaUsecase()
        {
            var mapper = MapperHelper.ConfigMapper();

            // var autenticacaoAppService = new AirplaneAppService(,mapper);

            // var teste = autenticacaoAppService.Listar();
        }
    }
}