#region

using System.Threading.Tasks;
using GitScraping.Application.Imports.ImportFunctions;
using GitScraping.UnitTests.Mocks;
using Xunit;

#endregion

namespace GitScraping.UnitTests.Tests.ImportTests
{
    public class ReadExcelFileSaxTests
    {
        private readonly ObterIFormFileMock _obterIFormFileMock = new();

        [Fact]
        public async Task ReadExcelFileSaxTest()
        {
            var arquivo = await _obterIFormFileMock.Execute();

            var result = ReadExcelFileSax.Execute(arquivo);

            Assert.NotEmpty(result);
            Assert.Equal(10, result.Count);
        }
    }
}