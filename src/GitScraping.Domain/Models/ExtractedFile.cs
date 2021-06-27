#region

using GitScraping.Domain.Bases;
using Octokit;

#endregion

namespace GitScraping.Domain.Models
{
    public class ExtractedFile : Entity
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public string Sha { get; set; }
        public int Lines { get; set; }
        public int Size { get; set; }
        public string Url { get; set; }
        public StringEnum<ContentType> Type { get; set; }
    }
}