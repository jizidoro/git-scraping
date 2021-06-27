#region

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitScraping.Domain.Models;
using Octokit;

#endregion

namespace GitScraping.Core.ExtractedFileCore.Usecase
{
    public class GetContentsOctokitUsecase : IGetContentsOctokitUsecase
    {
        public async Task Execute(string repositoryOwner, string repoName, string path, GitHubClient gitHubClient,
            List<ExtractedFile> files)
        {
            var extractedContents = await ExtractContentsGithubUsecase.Execute(repositoryOwner, repoName, path, gitHubClient);
            var extractedSource = extractedContents.Where(x => x.Type != "Dir");
            var extractedDirectory = extractedContents.Where(x => x.Type == "Dir");

            await ProcessNumberOfLinesUsecase.Execute(repositoryOwner, repoName, gitHubClient, files, extractedSource);

            foreach (var dir in extractedDirectory)
            {
                await Execute(repositoryOwner, repoName, dir.Path, gitHubClient, files);
            }
        }
    }
}