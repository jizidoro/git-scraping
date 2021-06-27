#region

using System.Collections.Generic;
using GitScraping.Application.Utils;

#endregion

namespace GitScraping.Application.Bases
{
    public class ResultDto : IResultDto
    {
        public int Codigo { get; set; }
        public bool Sucesso { get; set; }
    }
}