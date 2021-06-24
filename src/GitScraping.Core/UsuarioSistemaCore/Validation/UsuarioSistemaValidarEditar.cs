#region

using System.Threading.Tasks;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Models.Validations;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.UsuarioSistemaCore.Validation
{
    public class UsuarioSistemaValidarEditar : EntityValidation<UsuarioSistema>
    {
        private readonly IUsuarioSistemaRepository _repository;

        public UsuarioSistemaValidarEditar(IUsuarioSistemaRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<ISingleResult<UsuarioSistema>> Execute(UsuarioSistema entity)
        {
            var registroExiste = await RegistroExiste(entity.Id);
            if (!registroExiste.Sucesso)
            {
                return registroExiste;
            }

            return registroExiste;
        }
    }
}