#region

using GitScraping.Application.Dtos.AirplaneDtos;

#endregion

namespace GitScraping.Application.Validations.AirplaneValitation
{
    public class AirplaneEditarValidation : AirplaneValidation<AirplaneEditarDto>
    {
        public AirplaneEditarValidation()
        {
            ValidarId();
            ValidarCodigo();
            ValidarModelo();
            ValidarQuantidadePassageiro();
        }
    }
}