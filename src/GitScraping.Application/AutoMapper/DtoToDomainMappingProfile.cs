#region

using AutoMapper;
using GitScraping.Application.Dtos;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<ProcessedFileDto, ProcessedFile>();
        }
    }
}