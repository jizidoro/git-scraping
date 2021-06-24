#region

using System.Threading.Tasks;

#endregion

namespace GitScraping.Core.Helpers.Interfaces
{
    public interface IService
    {
        Task<bool> Commit();
    }
}