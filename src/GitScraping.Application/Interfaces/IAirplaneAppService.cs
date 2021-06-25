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
        Task<ListResultDto<AirplaneDto>> Listar(PaginationFilter paginationFilter = null);
    }
}