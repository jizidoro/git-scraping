#region

using System.Collections.Generic;
using GitScraping.Application.Services;
using GitScraping.Core.Helpers.Extensions;
using GitScraping.Core.Helpers.Models;
using GitScraping.Core.SecurityCore.Usecase;
using GitScraping.Core.SecurityCore.Validation;
using GitScraping.Core.UsuarioSistemaCore.Validation;
using GitScraping.Infrastructure.DataAccess;
using GitScraping.Infrastructure.Repositories;
using GitScraping.Infrastructure.Repositories.Views;
using GitScraping.UnitTests.Helpers;
using Microsoft.Extensions.Configuration;

#endregion

namespace GitScraping.UnitTests.Tests.AutenticacaoTests.Bases
{
    public sealed class AutenticacaoInjectionUseCase
    {
        public AtualizarSenhaExpiradaUsecase ObterAtualizarSenhaExpiradaUsecase(GitScrapingContext context)
        {
            var uow = new UnitOfWork(context);
            var usuarioSistemaCoreRepository = new UsuarioSistemaRepository(context);

            var usuarioSistemaCoreValidarEditar =
                new UsuarioSistemaValidarEditar(usuarioSistemaCoreRepository
                );
            var passwordHasher = new PasswordHasher(new HashingOptions());

            return new AtualizarSenhaExpiradaUsecase(usuarioSistemaCoreRepository,
                usuarioSistemaCoreValidarEditar, passwordHasher, uow);
        }

        public EsquecerSenhaUsecase ObterEsquecerSenhaUsecase(GitScrapingContext context)
        {
            var uow = new UnitOfWork(context);
            var usuarioSistemaCoreRepository = new UsuarioSistemaRepository(context);
            var usuarioSistemaValidarEditar = new UsuarioSistemaValidarEditar(usuarioSistemaCoreRepository);
            var usuarioSistemaValidarEsquecerSenha =
                new UsuarioSistemaValidarEsquecerSenha(usuarioSistemaCoreRepository, usuarioSistemaValidarEditar
                );
            var passwordHasher = new PasswordHasher(new HashingOptions());

            return new EsquecerSenhaUsecase(usuarioSistemaCoreRepository, usuarioSistemaValidarEsquecerSenha,
                passwordHasher, uow);
        }

        public GerarTokenLoginUsecase ObterGerarTokenLoginUsecase(GitScrapingContext context)
        {
            var myConfiguration = new Dictionary<string, string>
            {
                {"JWT:Key", "afsdkjasjflxswafsdklk434orqiwup3457u-34oewir4irroqwiffv48mfs"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();


            var uow = new UnitOfWork(context);
            var usuarioSistemaCoreRepository = new UsuarioSistemaRepository(context);

            var passwordHasher = new PasswordHasher(new HashingOptions());

            var usuarioSistemaValidarSenha =
                new UsuarioSistemaValidarSenha(usuarioSistemaCoreRepository, passwordHasher);
            var vUsuarioSistemaPermissaoRepository =
                new VwUsuarioSistemaPermissaoRepository(context);
            var gerarTokenLoginUsecase =
                new GerarTokenLoginUsecase
                (
                    configuration,
                    usuarioSistemaValidarSenha
                );
            return gerarTokenLoginUsecase;
        }

        private AutenticacaoAppService ObterUsuarioSistemaAppService(GitScrapingContext context)
        {
            var uow = new UnitOfWork(context);
            var vUsuarioSistemaRepository = new VwUsuarioSistemaPermissaoRepository(context);
            var mapper = MapperHelper.ConfigMapper();

            var oterAtualizarSenhaExpiradaUsecase = ObterAtualizarSenhaExpiradaUsecase(context);
            var obterEsquecerSenhaUsecase = ObterEsquecerSenhaUsecase(context);
            var obterGerarTokenLoginUsecaseUsecase = ObterGerarTokenLoginUsecase(context);

            var autenticacaoAppService = new AutenticacaoAppService(vUsuarioSistemaRepository,
                oterAtualizarSenhaExpiradaUsecase,
                obterGerarTokenLoginUsecaseUsecase, obterEsquecerSenhaUsecase, mapper);
            return autenticacaoAppService;
        }
    }
}