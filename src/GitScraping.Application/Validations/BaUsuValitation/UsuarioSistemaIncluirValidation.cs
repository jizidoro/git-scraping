#region

using GitScraping.Application.Dtos.UsuarioSistemaDtos;

#endregion

namespace GitScraping.Application.Validations.BaUsuValitation
{
    public class UsuarioSistemaIncluirValidation : UsuarioSistemaValidation<UsuarioSistemaIncluirDto>
    {
        public UsuarioSistemaIncluirValidation()
        {
            ValidarNome();
            ValidarEmail();
            ValidarSenha();
            ValidarMatricula();
        }
    }
}