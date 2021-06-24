#region

using GitScraping.Application.Bases;

#endregion

namespace GitScraping.Application.Dtos
{
    public class UsuarioDto : EntityDto
    {
        public string Token { get; set; }
    }
}