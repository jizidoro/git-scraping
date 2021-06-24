#region

using System.Threading.Tasks;

#endregion

namespace GitScraping.Core.Helpers.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        ///     Applies all database changes.
        /// </summary>
        /// <returns>Number of affected rows.</returns>
        Task<int> Save();

        Task<bool> Commit();
    }
}