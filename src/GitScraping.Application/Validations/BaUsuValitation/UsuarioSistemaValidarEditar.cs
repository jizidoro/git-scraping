#region

using GitScraping.Application.Dtos.UsuarioSistemaDtos;

#endregion

namespace GitScraping.Application.Validations.BaUsuValitation
{
    public class UsuarioSistemaEditarValidation : UsuarioSistemaValidation<UsuarioSistemaEditarDto>
    {
        public UsuarioSistemaEditarValidation()
        {
            ValidarId();
            ValidarNome();
            ValidarEmail();
            ValidarSenha();
            ValidarMatricula();
        }
    }
}