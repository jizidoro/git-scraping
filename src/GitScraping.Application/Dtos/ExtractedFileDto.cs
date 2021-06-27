#region

using GitScraping.Application.Bases;
using Octokit;

#endregion

namespace GitScraping.Application.Dtos
{
    public class ExtractedFileDto : EntityDto
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Sha { get; set; }
        public int Lines { get; set; }
        public int Size { get; set; }
        public string Url { get; set; }
        public StringEnum<ContentType> Type { get; set; }
    }
}