#region

using System;
using System.Reflection;
using System.Threading.Tasks;
using GitScraping.Application.Dtos.AirplaneDtos;
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
        private readonly ObterServiceProviderMemDb _obterServiceProviderMemDb = new();

        public ProcessFilesUseCaseTest(ITestOutputHelper output)
        {
            _output = output;
        }

        private const string JsonPath = "GitScraping.Domain.SeedData";

        [Fact]
        public async Task ProcessFilesUseCase_Returns_GroupedFiles()
        {
            var mapper = MapperHelper.ConfigMapper();

            var serviceProvider = _obterServiceProviderMemDb.Execute();

            var assembly = Assembly.GetAssembly(typeof(JsonUtilities));

            var extractedFiles = JsonUtilities.GetListFromJson<ExtractedFile>(
                assembly.GetManifestResourceStream($"{JsonPath}.scrappingFile.json"));

            var processFilesUseCaseUsecase = new ProcessFilesUseCaseUsecase();

            var result = await processFilesUseCaseUsecase.Execute(extractedFiles);

            // var teste = autenticacaoAppService.Listar();
        }
    }
}