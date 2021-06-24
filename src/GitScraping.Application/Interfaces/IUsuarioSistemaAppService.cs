#region

using System.Threading.Tasks;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos.UsuarioSistemaDtos;
using GitScraping.Application.Filters;
using GitScraping.Application.Utils;

#endregion

namespace GitScraping.Application.Interfaces
{
    public interface IUsuarioSistemaAppService : IAppService
    {
        Task<IPageResultDto<UsuarioSistemaDto>> Listar(PaginationFilter paginationFilter = null);
        Task<ListResultDto<LookupDto>> BuscarPorNome(string nome);
        Task<ISingleResultDto<UsuarioSistemaDto>> Obter(int id);
        Task<ISingleResultDto<EntityDto>> Incluir(UsuarioSistemaIncluirDto dto);
        Task<ISingleResultDto<EntityDto>> Editar(UsuarioSistemaEditarDto dto);
        Task<ISingleResultDto<EntityDto>> Excluir(int id);
    }
}