#region

using System;
using System.Linq;
using GitScraping.Core.UsuarioSistemaCore;
using GitScraping.Domain.Bases;
using GitScraping.Domain.Models;
using GitScraping.Infrastructure.Bases;
using GitScraping.Infrastructure.DataAccess;

#endregion

namespace GitScraping.Infrastructure.Repositories
{
    public class UsuarioSistemaRepository : Repository<UsuarioSistema>, IUsuarioSistemaRepository
    {
        private readonly GitScrapingContext _context;

        public UsuarioSistemaRepository(GitScrapingContext context)
            : base(context)
        {
            _context = context ??
                       throw new ArgumentNullException(nameof(context));
        }


        public IQueryable<LookupEntity> BuscarPorNome(string nome)
        {
            var result = Db.UsuarioSistemas
                .Where(x => x.Situacao &&
                            x.Nome.Contains(nome)).Take(30)
                .OrderBy(x => x.Nome)
                .Select(s => new LookupEntity {Key = s.Id, Value = s.Nome});

            return result;
        }
    }
}