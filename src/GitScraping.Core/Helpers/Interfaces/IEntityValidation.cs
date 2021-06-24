#region

using System.Threading.Tasks;
using GitScraping.Domain.Interfaces;

#endregion

namespace GitScraping.Core.Helpers.Interfaces
{
    public interface IEntityValidation<TEntity>
        where TEntity : IEntity
    {
        Task<ISingleResult<TEntity>> RegistroExiste(int id, params string[] includes);

        Task<ISingleResult<TEntity>> RegistroComMesmoCodigo(int id, string codigo);
    }
}