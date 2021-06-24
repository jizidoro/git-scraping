#region

using GitScraping.Application.Bases;

#endregion

namespace GitScraping.Application.Dtos
{
    public class AutenticacaoDto : EntityDto
    {
        public string Chave { get; set; }
        public string Senha { get; set; }
    }
}