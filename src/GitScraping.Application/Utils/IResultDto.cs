#region

using System.Collections.Generic;
using GitScraping.Core.Helpers.Interfaces;

#endregion

namespace GitScraping.Application.Utils
{
    public interface IResultDto : IResult
    {
        IList<string> Mensagens { get; set; }
    }
}