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
    public sealed class ServiceProviderTest
    {
        private readonly ITestOutputHelper _output;
        private readonly GetServiceProvider _getServiceProvider = new();

        public ServiceProviderTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ServiceProvider_Returns()
        {
            var result = _getServiceProvider.Execute();

            Assert.NotNull(result);
        }
    }
}