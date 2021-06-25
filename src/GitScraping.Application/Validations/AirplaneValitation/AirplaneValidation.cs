#region

using GitScraping.Application.Bases;
using GitScraping.Application.Dtos.AirplaneDtos;
using FluentValidation;

#endregion

namespace GitScraping.Application.Validations.AirplaneValitation
{
    public class AirplaneValidation<TDto> : DtoValidation<TDto>
        where TDto : AirplaneDto
    {
        protected void ValidarId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0);
        }

        protected void ValidarCodigo()
        {
            RuleFor(v => v.Codigo)
                .NotEmpty()
                .MaximumLength(255)
                .WithName("Codigo");
        }

        protected void ValidarModelo()
        {
            RuleFor(v => v.Modelo)
                .NotEmpty()
                .MaximumLength(255)
                .WithName("Modelo");
        }

        protected void ValidarQuantidadePassageiro()
        {
            RuleFor(v => v.QuantidadePassageiro)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithName("QuantidadePassageiro");
        }
    }
}