#region

using System;
using System.Reflection;
using System.Threading.Tasks;
using GitScraping.Core.ExtractedFileCore.Usecase;
using GitScraping.Domain.Models;
using GitScraping.Domain.Utils;
using GitScraping.UnitTests.Helpers;
using Octokit;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace GitScraping.UnitTests.Tests
{
    public sealed class ExtractContentsGithubUsecaseTest
    {
        private const string JsonPath = "GitScraping.Domain.SeedData";
        private readonly ITestOutputHelper _output;

        public ExtractContentsGithubUsecaseTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task ExtractContentsGithubUsecase_Returns()
        {
            string repositoryOwner = "yakkumo";
            string repoName = "git-scraping";
            string path = "/";
            GitHubClient gitHubClient = GitHubClientUsecase.Execute();

            var result = await ExtractContentsGithubUsecase.Execute(repositoryOwner, repoName, path, gitHubClient);

            Assert.NotNull(result);
        }
    }
}