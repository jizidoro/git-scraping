#region

using System.Threading.Tasks;
using GitScraping.Domain.Models;
using GitScraping.Infrastructure.DataAccess;
using GitScraping.Infrastructure.Repositories;
using GitScraping.UnitTests.Helpers;
using GitScraping.UnitTests.Tests.UsuarioSistemaTests.Bases;
using Microsoft.EntityFrameworkCore;
using Xunit;

#endregion

namespace GitScraping.IntegrationTests.Tests.UsuarioSistemaIntegrationTests
{
    public class UsuarioSistemaContextTests
    {
        private readonly UsuarioSistemaInjectionController _usuarioSistemaInjectionController = new();

        [Fact]
        public async Task UsuarioSistema_Context()
        {
            var options = new DbContextOptionsBuilder<GitScrapingContext>()
                .UseInMemoryDatabase("test_database_memoria_obter_usuario_sistema_Respositorio")
                .Options;

            UsuarioSistema usuarioSistema = null;

            await using var context = new GitScrapingContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            var repository = new UsuarioSistemaRepository(context);
            usuarioSistema = await repository.GetById(1);
            Assert.NotNull(usuarioSistema);
        }
    }
}