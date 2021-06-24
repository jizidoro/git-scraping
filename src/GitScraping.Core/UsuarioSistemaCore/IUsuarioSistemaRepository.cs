#region

using System.Linq;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Domain.Bases;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.UsuarioSistemaCore
{
    public interface IUsuarioSistemaRepository : IRepository<UsuarioSistema>
    {
        IQueryable<LookupEntity> BuscarPorNome(string nome);
    }
}