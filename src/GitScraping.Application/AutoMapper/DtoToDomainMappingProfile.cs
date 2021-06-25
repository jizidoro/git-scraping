#region

using AutoMapper;
using GitScraping.Application.Dtos;
using GitScraping.Application.Dtos.AirplaneDtos;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<AirplaneIncluirDto, Airplane>();
        }
    }
}