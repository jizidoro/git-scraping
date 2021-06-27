#region

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitScraping.Domain.Models;
using Octokit;

#endregion

namespace GitScraping.Core.ExtractedFileCore.Usecase
{
    public class GetAllSourceFilesFromRepositoryUsecase : IGetAllSourceFilesFromRepositoryUsecase
    {
        private readonly IGetContentsOctokitUsecase _getContentsOctokitUsecase;

        public GetAllSourceFilesFromRepositoryUsecase(IGetContentsOctokitUsecase getContentsOctokitUsecase)
        {
            _getContentsOctokitUsecase = getContentsOctokitUsecase;
        }

        public async Task<List<ExtractedFile>> Execute(string repositoryOwner, string repoName, GitHubClient gitHubClient)
        {
            var files = new List<ExtractedFile>();
            var path = "/";
            await _getContentsOctokitUsecase.Execute(repositoryOwner, repoName, path, gitHubClient, files);
            return files;
        }
        
    }
}