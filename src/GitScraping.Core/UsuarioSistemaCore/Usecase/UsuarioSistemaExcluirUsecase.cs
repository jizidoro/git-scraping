#region

using System;
using System.Threading.Tasks;
using GitScraping.Core.Helpers.Bases;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Messages;
using GitScraping.Core.Helpers.Models.Results;
using GitScraping.Core.UsuarioSistemaCore.Validation;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.UsuarioSistemaCore.Usecase
{
    public class UsuarioSistemaExcluirUsecase : Service
    {
        private readonly IUsuarioSistemaRepository _repository;
        private readonly UsuarioSistemaValidarExcluir _usuarioSistemaValidarExcluir;

        public UsuarioSistemaExcluirUsecase(IUsuarioSistemaRepository repository,
            UsuarioSistemaValidarExcluir usuarioSistemaValidarExcluir,
            IUnitOfWork uow)
            : base(uow)
        {
            _repository = repository;
            _usuarioSistemaValidarExcluir = usuarioSistemaValidarExcluir;
        }

        public async Task<ISingleResult<UsuarioSistema>> Execute(int id)
        {
            try
            {
                var validacao = await _usuarioSistemaValidarExcluir.Execute(id);
                if (!validacao.Sucesso) return validacao;

                _repository.Remove(id);

                var sucesso = await Commit();
            }
            catch (Exception)
            {
                return new SingleResult<UsuarioSistema>(MensagensNegocio.MSG07);
            }

            return new ExcluirResult<UsuarioSistema>();
        }
    }
}