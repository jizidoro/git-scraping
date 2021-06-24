#region

using System.Threading.Tasks;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Models.Validations;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.AirplaneCore.Validation
{
    public class AirplaneValidarExcluir : EntityValidation<Airplane>
    {
        private readonly IAirplaneRepository _repository;

        public AirplaneValidarExcluir(IAirplaneRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<ISingleResult<Airplane>> Execute(int id)
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