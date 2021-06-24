#region

using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Models.Results;
using GitScraping.Core.Helpers.Models.Validations;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.UsuarioSistemaCore.Validation
{
    public class UsuarioSistemaValidarIncluir : EntityValidation<UsuarioSistema>
    {
        private readonly IUsuarioSistemaRepository _repository;

        public UsuarioSistemaValidarIncluir(IUsuarioSistemaRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public ISingleResult<UsuarioSistema> Execute(UsuarioSistema entity)
        {
            return new SingleResult<UsuarioSistema>(entity);
        }
    }
}