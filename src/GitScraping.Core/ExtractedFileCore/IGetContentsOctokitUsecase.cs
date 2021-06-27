#region

using System.Collections.Generic;
using System.Threading.Tasks;
using GitScraping.Domain.Models;
using Octokit;

#endregion

namespace GitScraping.Core.ExtractedFileCore
{
    public interface IGetContentsOctokitUsecase
    {
        Task Execute(string repositoryOwner, string repoName, string path, GitHubClient gitHubClient,
            List<ExtractedFile> files);
    }
}