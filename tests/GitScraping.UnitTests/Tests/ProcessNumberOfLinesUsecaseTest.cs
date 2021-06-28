#region

using System;
using System.Collections.Generic;
using System.Linq;
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
    public sealed class ProcessNumberOfLinesUsecaseTest
    {
        private const string JsonPath = "GitScraping.Domain.SeedData";
        private readonly ITestOutputHelper _output;

        public ProcessNumberOfLinesUsecaseTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ProcessNumberOfLinesUsecase_Returns_GroupedFiles()
        {
            string repositoryOwner = "yakkumo";
            string repoName = "git-scraping";
            GitHubClient gitHubClient = GitHubClientUsecase.Execute();

            var assembly = Assembly.GetAssembly(typeof(JsonUtilities));

            if (assembly is not null)
            {
                var extractedFiles = JsonUtilities.GetListFromJson<ExtractedFile>(
                    assembly.GetManifestResourceStream($"{JsonPath}.scrappingFile.json"));
                List<ExtractedFile> files = new();
                List<ExtractedFile> extractedSource = extractedFiles.Where(x => x.Type != "dir").ToList();

                var result =
                    ProcessNumberOfLinesUsecase.Execute(repositoryOwner, repoName, gitHubClient, files,
                        extractedSource);

                Assert.NotNull(result);
            }
        }
    }
}