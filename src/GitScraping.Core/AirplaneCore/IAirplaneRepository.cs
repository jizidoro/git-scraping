#region

using System.Threading.Tasks;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.AirplaneCore
{
    public interface IAirplaneRepository : IRepository<Airplane>
    {
        Task<ISingleResult<Airplane>> RegistroCodigoRepetido(int id, string codigo);
    }
}