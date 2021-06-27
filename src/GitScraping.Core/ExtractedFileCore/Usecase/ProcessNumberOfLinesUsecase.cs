#region

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitScraping.Domain.Models;
using Octokit;

#endregion

namespace GitScraping.Core.ExtractedFileCore.Usecase
{
    public class ProcessNumberOfLinesUsecase
    {
        public static async Task Execute(string repositoryOwner, string repoName, GitHubClient gitHubClient,
            List<ExtractedFile> files,
            IEnumerable<ExtractedFile> extractedSource)
        {
            foreach (var file in extractedSource)
            {
                var fileContent = await gitHubClient.Repository.Content.GetAllContents(repositoryOwner, repoName, file.Path);
                var content = fileContent.FirstOrDefault()?.Content;

                if (content != null)
                {
                    var numberLines = content.Split('\n').Length;
                    file.Lines = numberLines;
                    files.Add(file);
                }
            }
        }

    }
}