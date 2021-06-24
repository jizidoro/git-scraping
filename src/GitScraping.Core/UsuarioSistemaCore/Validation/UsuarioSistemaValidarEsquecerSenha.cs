#region

using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Models.Results;
using GitScraping.Core.Helpers.Models.Validations;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.UsuarioSistemaCore.Validation
{
    public class UsuarioSistemaValidarEsquecerSenha : EntityValidation<UsuarioSistema>
    {
        private readonly IUsuarioSistemaRepository _repository;
        private readonly UsuarioSistemaValidarEditar _usuarioSistemaValidarEditar;

        public UsuarioSistemaValidarEsquecerSenha(IUsuarioSistemaRepository repository,
            UsuarioSistemaValidarEditar usuarioSistemaValidarEditar)
            : base(repository)
        {
            _repository = repository;
            _usuarioSistemaValidarEditar = usuarioSistemaValidarEditar;
        }

        public ISingleResult<UsuarioSistema> Execute(UsuarioSistema entity)
        {
            var registroExiste = _usuarioSistemaValidarEditar.Execute(entity).Result;

            if (!registroExiste.Sucesso)
            {
                return new SingleResult<UsuarioSistema>(1001, "Usuario não existe");
            }


            return registroExiste;
        }
    }
}