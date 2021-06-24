#region

using System.Threading.Tasks;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos;
using GitScraping.Application.Utils;

#endregion

namespace GitScraping.Application.Interfaces
{
    public interface IAutenticacaoAppService : IAppService
    {
        Task<ISingleResultDto<UsuarioDto>> GerarTokenLoginUsecase(AutenticacaoDto dto);
        Task<ISingleResultDto<EntityDto>> EsquecerSenha(AutenticacaoDto dto);
        Task<ISingleResultDto<EntityDto>> ExpirarSenha(AutenticacaoDto dto);
    }
}