#region

using System.Threading.Tasks;
using GitScraping.Application.Dtos;
using GitScraping.Infrastructure.DataAccess;
using GitScraping.UnitTests.Helpers;
using GitScraping.UnitTests.Tests.AutenticacaoTests.Bases;
using GitScraping.UnitTests.Tests.AutenticacaoTests.TestDatas;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace GitScraping.UnitTests.Tests.AutenticacaoTests
{
    public sealed class GerarTokenUsecaseTests

    {
        private readonly AutenticacaoInjectionUseCase _autenticacaoInjectionUseCase = new();
        private readonly ITestOutputHelper _output;

        public GerarTokenUsecaseTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [ClassData(typeof(AutenticacaoDtoTestData))]
        public async Task Test_GerarTokenLoginUsecase(int expected, AutenticacaoDto testeEntrada)
        {
            var options = new DbContextOptionsBuilder<GitScrapingContext>()
                .UseInMemoryDatabase("test_database_memoria_token" + testeEntrada.Chave)
                .Options;
            await using var context = new GitScrapingContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);

            var gerarTokenLoginUsecase = _autenticacaoInjectionUseCase.ObterGerarTokenLoginUsecase(context);
            var result = await gerarTokenLoginUsecase.Execute(testeEntrada.Chave, testeEntrada.Senha);
            Assert.Equal(expected, result.Code);
        }
    }
}