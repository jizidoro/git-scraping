#region

using AutoMapper;
using GitScraping.Application.AutoMapper;
using GitScraping.Application.MappingProfiles;

#endregion

namespace GitScraping.UnitTests.Helpers
{
    public class MapperHelper
    {
        public static IMapper ConfigMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToDomainMappingProfile());
                cfg.AddProfile(new DomainToDtoMappingProfile());
                cfg.AddProfile(new RequestToDomainProfile());
            }).CreateMapper();
        }
    }
}