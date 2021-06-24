#region

using System.Linq;
using System.Threading.Tasks;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos.UsuarioSistemaDtos;
using GitScraping.Infrastructure.DataAccess;
using GitScraping.UnitTests.Tests.UsuarioSistemaTests.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

#endregion

namespace GitScraping.IntegrationTests.Tests.UsuarioSistemaIntegrationTests
{
    public sealed class UsuarioSistemaControllerIncluirTests
    {
        private readonly UsuarioSistemaInjectionController _usuarioSistemaInjectionController = new();

        [Fact]
        public async Task UsuarioSistemaController_Incluir()
        {
            var options = new DbContextOptionsBuilder<GitScrapingContext>()
                .UseInMemoryDatabase("test_database_memoria_incluir_usuario_sistema")
                .Options;


            var teste = new UsuarioSistemaIncluirDto
            {
                Nome = "111",
                Email = "777@teste",
                Senha = "123456",
                Situacao = true,
                Matricula = "123"
            };


            await using var context = new GitScrapingContext(options);
            await context.Database.EnsureCreatedAsync();
            var usuarioSistemaController = _usuarioSistemaInjectionController.ObterUsuarioSistemaController(context);
            _ = await usuarioSistemaController.Incluir(teste);
            Assert.Equal(1, context.UsuarioSistemas.Count());
        }


        [Fact]
        public async Task UsuarioSistemaController_Incluir_Erro()
        {
            var options = new DbContextOptionsBuilder<GitScrapingContext>()
                .UseInMemoryDatabase("test_database_memoria_incluir_usuario_sistema_erro")
                .Options;

            var teste = new UsuarioSistemaIncluirDto
            {
                Email = "777@teste",
                Senha = "123456",
                Situacao = true,
                Matricula = "123"
            };

            await using var context = new GitScrapingContext(options);
            await context.Database.EnsureCreatedAsync();
            var usuarioSistemaController = _usuarioSistemaInjectionController.ObterUsuarioSistemaController(context);
            var result = await usuarioSistemaController.Incluir(teste);

            if (result is OkObjectResult okObjectResult)
            {
                var actualResultValue = okObjectResult.Value as SingleResultDto<EntityDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(400, actualResultValue.Codigo);
            }

            Assert.False(context.UsuarioSistemas.Any());
        }
    }
}