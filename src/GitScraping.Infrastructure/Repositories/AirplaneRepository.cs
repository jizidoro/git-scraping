#region

using System;
using System.Linq;
using System.Threading.Tasks;
using GitScraping.Core.AirplaneCore;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Messages;
using GitScraping.Core.Helpers.Models.Results;
using GitScraping.Domain.Models;
using GitScraping.Infrastructure.Bases;
using GitScraping.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

#endregion

namespace GitScraping.Infrastructure.Repositories
{
    public class AirplaneRepository : Repository<Airplane>, IAirplaneRepository
    {
        private readonly GitScrapingContext _context;

        public AirplaneRepository(GitScrapingContext context)
            : base(context)
        {
            _context = context ??
                       throw new ArgumentNullException(nameof(context));
        }

        public async Task<ISingleResult<Airplane>> RegistroCodigoRepetido(int id, string codigo)
        {
            var existe = await Db.Airplanes
                .Where(p => p.Id != id && p.Codigo.Equals(codigo))
                .AnyAsync();

            return existe ? new SingleResult<Airplane>(MensagensNegocio.MSG08) : new SingleResult<Airplane>();
        }
    }
}