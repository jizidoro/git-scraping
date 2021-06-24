#region

using GitScraping.Application.Bases;

#endregion

namespace GitScraping.Application.Utils
{
    public interface ISingleResultDto<TDto> : IResultDto
        where TDto : Dto
    {
        TDto Data { get; }
    }
}