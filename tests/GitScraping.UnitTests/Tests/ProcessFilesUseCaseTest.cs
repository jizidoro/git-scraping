#region

using System.Reflection;
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
        private const string JsonPath = "GitScraping.Domain.SeedData";
        private readonly getServiceProviderMemDb _getServiceProviderMemDb = new();
        private readonly ITestOutputHelper _output;

        public ProcessFilesUseCaseTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ProcessFilesUseCase_Returns_GroupedFiles()
        {
            var assembly = Assembly.GetAssembly(typeof(JsonUtilities));

            if (assembly is not null)
            {
                var extractedFiles = JsonUtilities.GetListFromJson<ExtractedFile>(
                    assembly.GetManifestResourceStream($"{JsonPath}.scrappingFile.json"));

                var processFilesUsecase = new ProcessFilesUsecase();

                var result = processFilesUsecase.Execute(extractedFiles);

                Assert.NotNull(result);
            }
        }
    }
}