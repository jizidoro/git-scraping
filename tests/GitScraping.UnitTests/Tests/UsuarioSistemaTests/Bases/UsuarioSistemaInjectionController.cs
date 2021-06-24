#region

using GitScraping.Infrastructure.DataAccess;
using GitScraping.UnitTests.Helpers;
using GitScraping.WebApi.UseCases.V1.UsuarioSistemaApi;

#endregion

namespace GitScraping.UnitTests.Tests.UsuarioSistemaTests.Bases
{
    public class UsuarioSistemaInjectionController
    {
        private readonly UsuarioSistemaInjectionAppService _usuarioSistemaInjectionAppService = new();

        public UsuarioSistemaController ObterUsuarioSistemaController(GitScrapingContext context)
        {
            var mapper = MapperHelper.ConfigMapper();
            var usuarioSistemaAppService =
                _usuarioSistemaInjectionAppService.ObterUsuarioSistemaAppService(context, mapper);

            return new UsuarioSistemaController(usuarioSistemaAppService, mapper);
        }
    }
}