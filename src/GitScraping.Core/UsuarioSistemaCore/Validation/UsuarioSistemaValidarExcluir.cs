#region

using System.Threading.Tasks;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Models.Validations;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.UsuarioSistemaCore.Validation
{
    public class UsuarioSistemaValidarExcluir : EntityValidation<UsuarioSistema>
    {
        private readonly IUsuarioSistemaRepository _repository;

        public UsuarioSistemaValidarExcluir(IUsuarioSistemaRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<ISingleResult<UsuarioSistema>> Execute(int id)
        {
            var registroExiste = await RegistroExiste(id);
            if (!registroExiste.Sucesso)
            {
                return registroExiste;
            }

            return registroExiste;
        }
    }
}