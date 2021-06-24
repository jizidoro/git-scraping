#region

using System.Linq;
using GitScraping.Domain.Models.Views;

#endregion

namespace GitScraping.Core.Views.VBaUsuPermissaoCore
{
    public interface IVwUsuarioSistemaPermissaoRepository
    {
        IQueryable<VwUsuarioSistemaPermissao> ListarPorSqUsuarioSistema(int sqUsuarioSistema);
    }
}