#region

using System.Collections.Generic;
using System.Threading.Tasks;
using GitScraping.Domain.Models;
using Octokit;

#endregion

namespace GitScraping.Core.ExtractedFileCore
{
    public interface IGetAllSourceFilesFromRepositoryUsecase
    {
        Task<List<ExtractedFile>> Execute(string repositoryOwner, string repoName, GitHubClient gitHubClient);
    }
}