#region

using System;
using System.Reflection;
using System.Threading.Tasks;
using GitScraping.Application.Services;
using GitScraping.Core.ExtractedFileCore.Usecase;
using GitScraping.Domain.Models;
using GitScraping.Domain.Utils;
using GitScraping.UnitTests.Helpers;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace GitScraping.UnitTests.Tests
{
    public sealed class ProcessFilesUseCaseTest
    {
        private readonly ITestOutputHelper _output;
        private readonly getServiceProviderMemDb _getServiceProviderMemDb = new();

        public ProcessFilesUseCaseTest(ITestOutputHelper output)
        {
            _output = output;
        }

        private const string JsonPath = "GitScraping.Domain.SeedData";

        [Fact]
        public void ProcessFilesUseCase_Returns_GroupedFiles()
        {
            var assembly = Assembly.GetAssembly(typeof(JsonUtilities));

            if (assembly is not null)
            {
                var extractedFiles = JsonUtilities.GetListFromJson<ExtractedFile>(
                    assembly.GetManifestResourceStream($"{JsonPath}.scrappingFile.json"));

                var processFilesUseCaseUsecase = new ProcessFilesUseCaseUsecase();

                var result = processFilesUseCaseUsecase.Execute(extractedFiles);

                Assert.NotNull(result);
            }
        }
    }
}