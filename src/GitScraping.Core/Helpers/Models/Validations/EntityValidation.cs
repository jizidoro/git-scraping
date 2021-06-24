#region

using System.Threading.Tasks;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Messages;
using GitScraping.Core.Helpers.Models.Results;
using GitScraping.Domain.Bases;

#endregion

namespace GitScraping.Core.Helpers.Models.Validations
{
    public class EntityValidation<TEntity> : IEntityValidation<TEntity>
        where TEntity : Entity
    {
        private readonly IRepository<TEntity> _repository;

        public EntityValidation(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<ISingleResult<TEntity>> RegistroExiste(int id, params string[] includes)
        {
            var entity = await _repository.GetById(id, includes);
            if (entity == null) return new SingleResult<TEntity>(MensagensNegocio.MSG04);

            return new SingleResult<TEntity>(entity);
        }

        public async Task<ISingleResult<TEntity>> RegistroComMesmoCodigo(int id, string codigo)
        {
            var result = await _repository.ValueExists(id, codigo);
            if (result) return new SingleResult<TEntity>(MensagensNegocio.MSG08);

            return new SingleResult<TEntity>();
        }
    }
}