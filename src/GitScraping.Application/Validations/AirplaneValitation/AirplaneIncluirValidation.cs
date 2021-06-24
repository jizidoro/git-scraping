#region

using GitScraping.Application.Dtos.AirplaneDtos;

#endregion

namespace GitScraping.Application.Validations.AirplaneValitation
{
    public class AirplaneIncluirValidation : AirplaneValidation<AirplaneIncluirDto>
    {
        public AirplaneIncluirValidation()
        {
            ValidarCodigo();
            ValidarModelo();
            ValidarQuantidadePassageiro();
        }
    }
}