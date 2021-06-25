#region

using AutoMapper;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos;
using GitScraping.Application.Dtos.AirplaneDtos;
using GitScraping.Domain.Bases;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Entity, EntityDto>();

            CreateMap<Airplane, AirplaneEditarDto>();
            CreateMap<Airplane, AirplaneDto>();
        }
    }
}