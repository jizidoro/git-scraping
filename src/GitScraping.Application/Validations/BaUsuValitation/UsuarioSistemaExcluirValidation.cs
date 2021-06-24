#region

using GitScraping.Application.Dtos.UsuarioSistemaDtos;

#endregion

namespace GitScraping.Application.Validations.BaUsuValitation
{
    public class UsuarioSistemaExcluirValidation : UsuarioSistemaValidation<UsuarioSistemaDto>
    {
        public UsuarioSistemaExcluirValidation()
        {
            ValidarId();
        }
    }
}