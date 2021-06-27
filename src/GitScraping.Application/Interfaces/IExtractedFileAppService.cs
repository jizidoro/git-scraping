#region

using System.Collections.Generic;
using System.Threading.Tasks;
using GitScraping.Application.Dtos;
using GitScraping.Application.Utils;

#endregion

namespace GitScraping.Application.Interfaces
{
    public interface IExtractedFileAppService : IAppService
    {
        Task<List<ProcessedFileDto>> GetReportByLanguage(string repositoryOwner, string repositoryName);
    }
}