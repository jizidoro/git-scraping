#region

using AutoMapper;

#endregion

namespace GitScraping.Application.Utils
{
    public interface IAppService
    {
        IMapper Mapper { get; }
    }
}