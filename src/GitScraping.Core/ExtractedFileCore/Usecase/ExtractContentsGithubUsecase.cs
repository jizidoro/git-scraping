#region

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitScraping.Domain.Models;
using Octokit;

#endregion

namespace GitScraping.Core.ExtractedFileCore.Usecase
{
    public class ExtractContentsGithubUsecase
    {
        public static async Task<List<ExtractedFile>> Execute(string repositoryOwner, string repoName, string path,
            GitHubClient gitHubClient)
        {
            var contents = await gitHubClient.Repository.Content.GetAllContents(repositoryOwner, repoName, path);
            var extractedContents = contents.Select(x =>
            {
                var dto = new ExtractedFile
                {
                    Name = x.Name,
                    Path = x.Path,
                    Sha = x.Sha,
                    Type = x.Type,
                    Url = x.Url,
                    Size = x.Size
                };
                return dto;
            }).ToList();
            return extractedContents;
        }
    }
}