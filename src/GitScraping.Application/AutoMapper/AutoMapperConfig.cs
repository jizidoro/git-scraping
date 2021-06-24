#region

using AutoMapper;
using GitScraping.Application.MappingProfiles;

#endregion

namespace GitScraping.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new(cfg =>
            {
                cfg.AddProfile(new DomainToDtoMappingProfile());
                cfg.AddProfile(new DtoToDomainMappingProfile());
                cfg.AddProfile(new RequestToDomainProfile());
            });
        }
    }
}