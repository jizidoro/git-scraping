#region

using System.Collections.Generic;
using GitScraping.External.Bases;

#endregion

namespace GitScraping.External.Utils
{
    public interface IListResultDto<T>
    {
        IList<T> Data { get; set; }
    }
}