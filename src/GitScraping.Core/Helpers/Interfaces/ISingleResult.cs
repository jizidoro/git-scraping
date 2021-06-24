#region

using GitScraping.Domain.Interfaces;

#endregion

namespace GitScraping.Core.Helpers.Interfaces
{
    public interface ISingleResult<TEntity> : IResult
        where TEntity : IEntity
    {
        TEntity Data { get; set; }
    }
}