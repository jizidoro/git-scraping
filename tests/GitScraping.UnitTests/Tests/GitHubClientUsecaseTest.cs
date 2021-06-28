#region

using System;
using System.Reflection;
using System.Threading.Tasks;
using GitScraping.Core.ExtractedFileCore.Usecase;
using GitScraping.Domain.Models;
using GitScraping.Domain.Utils;
using GitScraping.UnitTests.Helpers;
using NSubstitute;
using Octokit;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace GitScraping.UnitTests.Tests
{
    public sealed class GitHubClientUsecaseTest
    {
        private const string JsonPath = "GitScraping.Domain.SeedData";
        private readonly ITestOutputHelper _output;

        public GitHubClientUsecaseTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GitHubClientUsecase_Returns()
        {
            var result = GitHubClientUsecase.Execute();

            Assert.NotNull(result);
        }
    }
}