#region

using AutoMapper;
using GitScraping.Application.Services;
using GitScraping.Core.Helpers.Extensions;
using GitScraping.Core.Helpers.Models;
using GitScraping.Core.UsuarioSistemaCore.Usecase;
using GitScraping.Core.UsuarioSistemaCore.Validation;
using GitScraping.Infrastructure.DataAccess;
using GitScraping.Infrastructure.Repositories;

#endregion

namespace GitScraping.UnitTests.Tests.UsuarioSistemaTests.Bases
{
    public sealed class UsuarioSistemaInjectionAppService
    {
        public UsuarioSistemaAppService ObterUsuarioSistemaAppService(GitScrapingContext context, IMapper mapper)
        {
            var uow = new UnitOfWork(context);
            var usuarioSistemaRepository = new UsuarioSistemaRepository(context);
            var passwordHasher = new PasswordHasher(new HashingOptions());

            var usuarioSistemaValidarEditar =
                new UsuarioSistemaValidarEditar(usuarioSistemaRepository);
            var usuarioSistemaValidarExcluir = new UsuarioSistemaValidarExcluir(usuarioSistemaRepository);
            var usuarioSistemaValidarIncluir =
                new UsuarioSistemaValidarIncluir(usuarioSistemaRepository);
            var usuarioSistemaIncluirUsecase =
                new UsuarioSistemaIncluirUsecase(usuarioSistemaRepository, usuarioSistemaValidarIncluir, passwordHasher,
                    uow);
            var usuarioSistemaExcluirUsecase =
                new UsuarioSistemaExcluirUsecase(usuarioSistemaRepository, usuarioSistemaValidarExcluir, uow);
            var usuarioSistemaEditarUsecase =
                new UsuarioSistemaEditarUsecase(usuarioSistemaRepository, usuarioSistemaValidarEditar, uow);

            return new UsuarioSistemaAppService(usuarioSistemaRepository, usuarioSistemaEditarUsecase,
                usuarioSistemaIncluirUsecase,
                usuarioSistemaExcluirUsecase, mapper);
        }
    }
}