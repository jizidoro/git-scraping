#region

using GitScraping.Application.Extensions;
using Xunit;

#endregion

namespace GitScraping.UnitTests.Tests.UtilTests
{
    public class StringExtensionToPascalCaseTests
    {
        [Fact]
        public void StringExtension_ToPascalCase()
        {
            var teste = "Last in Line";
            var objetivo = "LastInLine";

            var restult = teste.ToPascalCase();

            Assert.NotEmpty(restult);
            Assert.Equal(restult, objetivo);
        }
    }
}