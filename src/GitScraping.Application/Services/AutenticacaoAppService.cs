#region

using System.Threading.Tasks;
using AutoMapper;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos;
using GitScraping.Application.Interfaces;
using GitScraping.Application.Utils;
using GitScraping.Core.SecurityCore.Usecase;
using GitScraping.Core.Views.VBaUsuPermissaoCore;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Application.Services
{
    public class AutenticacaoAppService : AppService, IAutenticacaoAppService
    {
        private readonly AtualizarSenhaExpiradaUsecase _atualizarSenhaExpiradaUsecase;
        private readonly EsquecerSenhaUsecase _esquecerSenhaUsecase;
        private readonly GerarTokenLoginUsecase _gerarTokenLoginUsecase;
        private readonly IVwUsuarioSistemaPermissaoRepository _vUsuarioSistemaPermissaoRepository;

        public AutenticacaoAppService(IVwUsuarioSistemaPermissaoRepository vUsuarioSistemaPermissaoRepository,
            AtualizarSenhaExpiradaUsecase atualizarSenhaExpiradaUsecase,
            GerarTokenLoginUsecase gerarTokenLoginUsecase, EsquecerSenhaUsecase esquecerSenhaUsecase, IMapper mapper) :
            base(mapper)
        {
            _vUsuarioSistemaPermissaoRepository = vUsuarioSistemaPermissaoRepository;
            _atualizarSenhaExpiradaUsecase = atualizarSenhaExpiradaUsecase;
            _esquecerSenhaUsecase = esquecerSenhaUsecase;
            _gerarTokenLoginUsecase = gerarTokenLoginUsecase;
        }

        public async Task<ISingleResultDto<UsuarioDto>> GerarTokenLoginUsecase(AutenticacaoDto dto)
        {
            var result = await _gerarTokenLoginUsecase.Execute(dto.Chave, dto.Senha);

            if (result.Success)
            {
                var token = new UsuarioDto
                {
                    Token = result.User.Token
                };

                return new SingleResultDto<UsuarioDto>(token);
            }

            return new SingleResultDto<UsuarioDto>(result);
        }

        public async Task<ISingleResultDto<EntityDto>> EsquecerSenha(AutenticacaoDto dto)
        {
            var evento = Mapper.Map<UsuarioSistema>(dto);

            var result = await _esquecerSenhaUsecase.Execute(evento);

            var resultDto = new SingleResultDto<EntityDto>(result);
            resultDto.SetData(result, Mapper);

            return resultDto;
        }

        public async Task<ISingleResultDto<EntityDto>> ExpirarSenha(AutenticacaoDto dto)
        {
            var evento = Mapper.Map<UsuarioSistema>(dto);

            var result = await _atualizarSenhaExpiradaUsecase.Execute(evento);

            var resultDto = new SingleResultDto<EntityDto>(result);
            resultDto.SetData(result, Mapper);

            return resultDto;
        }
    }
}