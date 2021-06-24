#region

using System;
using System.Threading.Tasks;
using GitScraping.Core.Helpers.Bases;
using GitScraping.Core.Helpers.Extensions;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Messages;
using GitScraping.Core.Helpers.Models.Results;
using GitScraping.Core.UsuarioSistemaCore.Validation;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.UsuarioSistemaCore.Usecase
{
    public class UsuarioSistemaIncluirUsecase : Service
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsuarioSistemaRepository _repository;
        private readonly UsuarioSistemaValidarIncluir _usuarioSistemaValidarIncluir;

        public UsuarioSistemaIncluirUsecase(IUsuarioSistemaRepository repository,
            UsuarioSistemaValidarIncluir usuarioSistemaValidarIncluir,
            IPasswordHasher passwordHasher, IUnitOfWork uow)
            : base(uow)
        {
            _repository = repository;
            _usuarioSistemaValidarIncluir = usuarioSistemaValidarIncluir;
            _passwordHasher = passwordHasher;
        }

        public async Task<ISingleResult<UsuarioSistema>> Execute(UsuarioSistema entity)
        {
            try
            {
                var isValid = ValidarEntidade(entity);
                if (!isValid.Sucesso)
                {
                    return isValid;
                }

                var validacao = _usuarioSistemaValidarIncluir.Execute(entity);
                if (!validacao.Sucesso) return validacao;

                entity.Senha = _passwordHasher.Hash(entity.Senha);
                entity.DataRegistro = HorariosFusoExtensions.ObterHorarioBrasilia();

                await _repository.Add(entity);

                var sucesso = await Commit();
            }
            catch (Exception)
            {
                return new SingleResult<UsuarioSistema>(MensagensNegocio.MSG07);
            }

            return new IncluirResult<UsuarioSistema>(entity);
        }
    }
}