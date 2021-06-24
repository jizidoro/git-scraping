#region

using System.Threading.Tasks;
using GitScraping.Core.Utils;

#endregion

namespace GitScraping.Core.SecurityCore
{
    public interface IGerarTokenLoginUsecase
    {
        Task<SecurityResult> Execute(string chave, string senha);
    }
}