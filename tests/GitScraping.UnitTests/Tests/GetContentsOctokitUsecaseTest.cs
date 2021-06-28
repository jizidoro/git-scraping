#region

using System;
using System.Collections.Generic;
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
    public sealed class GetContentsOctokitUsecaseTest
    {
        private const string JsonPath = "GitScraping.Domain.SeedData";
        private readonly ITestOutputHelper _output;

        public GetContentsOctokitUsecaseTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GetContentsOctokitUsecase_Returns()
        {
            var getContentsOctokitUsecase = new GetContentsOctokitUsecase();

            string repositoryOwner = "yakkumo";
            string repoName = "git-scraping";
            string path = "/";
            GitHubClient gitHubClient = GitHubClientUsecase.Execute();
            List<ExtractedFile> files = new();


            var result = getContentsOctokitUsecase.Execute(repositoryOwner, repoName, path, gitHubClient, files);

            Assert.NotNull(result);
        }
    }
}