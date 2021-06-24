#region

using System.Threading.Tasks;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Models.Validations;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.AirplaneCore.Validation
{
    public class AirplaneValidarEditar : EntityValidation<Airplane>
    {
        private readonly AirplaneValidarCodigoRepetido _airplaneValidarCodigoRepetido;
        private readonly IAirplaneRepository _repository;

        public AirplaneValidarEditar(IAirplaneRepository repository,
            AirplaneValidarCodigoRepetido airplaneValidarCodigoRepetido)
            : base(repository)
        {
            _repository = repository;
            _airplaneValidarCodigoRepetido = airplaneValidarCodigoRepetido;
        }

        public async Task<ISingleResult<Airplane>> Execute(Airplane entity)
        {
            var registroExiste = await RegistroExiste(entity.Id);
            if (!registroExiste.Sucesso) return registroExiste;

            var registroCodigoRepetido = await _airplaneValidarCodigoRepetido.Execute(entity);
            if (!registroCodigoRepetido.Sucesso) return registroCodigoRepetido;

            registroCodigoRepetido.Data = registroExiste.Data;

            return registroCodigoRepetido;
        }
    }
}