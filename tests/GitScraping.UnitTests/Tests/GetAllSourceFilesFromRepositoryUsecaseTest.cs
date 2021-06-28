#region

using System;
using System.Reflection;
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
    public sealed class GetAllSourceFilesFromRepositoryUsecaseTest
    {
        private const string JsonPath = "GitScraping.Domain.SeedData";
        private readonly ITestOutputHelper _output;

        public GetAllSourceFilesFromRepositoryUsecaseTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GetAllSourceFilesFromRepositoryUsecase_Returns()
        {
            var getContentsOctokitUsecase = new GetContentsOctokitUsecase();
            var getAllSourceFilesFromRepositoryUsecase =
                new GetAllSourceFilesFromRepositoryUsecase(getContentsOctokitUsecase);

            string repositoryOwner = "yakkumo";
            string repoName = "git-scraping";
            GitHubClient gitHubClient = GitHubClientUsecase.Execute();


            var result = getAllSourceFilesFromRepositoryUsecase.Execute(repositoryOwner, repoName, gitHubClient);

            Assert.NotNull(result);
        }
    }
}