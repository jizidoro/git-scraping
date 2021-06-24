#region

using AutoMapper;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos;
using GitScraping.Application.Dtos.AirplaneDtos;
using GitScraping.Application.Dtos.UsuarioSistemaDtos;
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
            CreateMap<LookupEntity, LookupDto>();

            CreateMap<Airplane, AirplaneEditarDto>();
            CreateMap<Airplane, AirplaneDto>();

            CreateMap<UsuarioSistema, UsuarioSistemaEditarDto>();
            CreateMap<UsuarioSistema, UsuarioSistemaDto>();

            CreateMap<UsuarioSistema, AutenticacaoDto>()
                .ForMember(dest => dest.Chave, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha));
        }
    }
}