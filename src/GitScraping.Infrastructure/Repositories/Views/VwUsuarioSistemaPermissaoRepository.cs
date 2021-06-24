#region

using System.Linq;
using GitScraping.Core.Views.VBaUsuPermissaoCore;
using GitScraping.Domain.Models.Views;
using GitScraping.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

#endregion

namespace GitScraping.Infrastructure.Repositories.Views
{
    public class VwUsuarioSistemaPermissaoRepository : IVwUsuarioSistemaPermissaoRepository
    {
        protected readonly GitScrapingContext Db;
        protected readonly DbSet<VwUsuarioSistemaPermissao> DbSet;

        public VwUsuarioSistemaPermissaoRepository(GitScrapingContext context)
        {
            Db = context;
            DbSet = Db.Set<VwUsuarioSistemaPermissao>();
        }


        public IQueryable<VwUsuarioSistemaPermissao> ListarPorSqUsuarioSistema(int sqUsuarioSistema)
        {
            var permissoes = Db.VUsuarioSistemaPermissoes
                .AsQueryable();

            return permissoes;
        }
    }
}