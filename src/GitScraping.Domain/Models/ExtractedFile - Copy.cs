#region

using GitScraping.Domain.Bases;
using Octokit;

#endregion

namespace GitScraping.Domain.Models
{
    public class ProcessedFile : Entity
    {
        public string Extension { get; set; }
        public string Count { get; set; }
        public string Lines { get; set; }
        public int Bytes { get; set; }
    }
}