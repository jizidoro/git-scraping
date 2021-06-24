#region

using System.Threading.Tasks;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos.AirplaneDtos;
using GitScraping.Application.Filters;
using GitScraping.Application.Utils;

#endregion

namespace GitScraping.Application.Interfaces
{
    public interface IAirplaneAppService : IAppService
    {
        Task<IPageResultDto<AirplaneDto>> Listar(PaginationFilter paginationFilter = null);
        Task<ISingleResultDto<AirplaneDto>> Obter(int id);
        Task<ISingleResultDto<EntityDto>> Incluir(AirplaneIncluirDto dto);
        Task<ISingleResultDto<EntityDto>> Editar(AirplaneEditarDto dto);
        Task<ISingleResultDto<EntityDto>> Excluir(int id);
    }
}