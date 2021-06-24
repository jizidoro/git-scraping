#region

using GitScraping.Infrastructure.DataAccess;

#endregion

namespace GitScraping.UnitTests.Helpers
{
    public class GetContextWithData
    {
        public GitScrapingContext Excute(GitScrapingContext context)
        {
            context.SaveChanges();

            return context;
        }
    }
}