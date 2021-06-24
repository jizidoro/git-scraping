#region

using AutoMapper;
using GitScraping.Application.Utils;

#endregion

namespace GitScraping.Application.Bases
{
    public class AppService : IAppService
    {
        public AppService(IMapper mapper)
        {
            Mapper = mapper;
        }

        public IMapper Mapper { get; }
    }
}