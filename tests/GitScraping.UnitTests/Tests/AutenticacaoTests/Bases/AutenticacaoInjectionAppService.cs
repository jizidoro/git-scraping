#region

using GitScraping.Application.Services;
using GitScraping.Infrastructure.DataAccess;
using GitScraping.Infrastructure.Repositories.Views;
using GitScraping.UnitTests.Helpers;

#endregion

namespace GitScraping.UnitTests.Tests.AutenticacaoTests.Bases
{
    public class AutenticacaoInjectionAppService
    {
        private readonly AutenticacaoInjectionUseCase _autenticacaoInjectionUseCase = new();

        public AutenticacaoAppService ObterAutenticacaoAppServiceService(GitScrapingContext context)
        {
            var uow = new UnitOfWork(context);
            var vUsuarioSistemaRepository = new VwUsuarioSistemaPermissaoRepository(context);
            var mapper = MapperHelper.ConfigMapper();

            var oterAtualizarSenhaExpiradaUsecase =
                _autenticacaoInjectionUseCase.ObterAtualizarSenhaExpiradaUsecase(context);
            var obterEsquecerSenhaUsecase =
                _autenticacaoInjectionUseCase.ObterEsquecerSenhaUsecase(context);
            var obterGerarTokenLoginUsecaseUsecase =
                _autenticacaoInjectionUseCase.ObterGerarTokenLoginUsecase(context);

            var autenticacaoAppService = new AutenticacaoAppService(vUsuarioSistemaRepository,
                oterAtualizarSenhaExpiradaUsecase,
                obterGerarTokenLoginUsecaseUsecase, obterEsquecerSenhaUsecase, mapper);
            return autenticacaoAppService;
        }
    }
}