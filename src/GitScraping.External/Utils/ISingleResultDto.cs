#region

using GitScraping.External.Bases;

#endregion

namespace GitScraping.External.Utils
{
    public interface ISingleResultDto<TDto>
        where TDto : Dto
    {
        TDto Data { get; }
    }
}