#region

using System.Collections.Generic;
using GitScraping.Application.Utils;

#endregion

namespace GitScraping.Application.Bases
{
    public class ResultDto : IResultDto
    {
        public string Mensagem { get; set; }
        public int Codigo { get; set; }
        public bool Sucesso { get; set; }
    }
}