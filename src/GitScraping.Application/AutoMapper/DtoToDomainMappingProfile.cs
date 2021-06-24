#region

using AutoMapper;
using GitScraping.Application.Dtos;
using GitScraping.Application.Dtos.AirplaneDtos;
using GitScraping.Application.Dtos.UsuarioSistemaDtos;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<AirplaneIncluirDto, Airplane>();
            CreateMap<UsuarioSistemaIncluirDto, UsuarioSistema>();
            CreateMap<AutenticacaoDto, UsuarioSistema>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Chave))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha));
        }
    }
}