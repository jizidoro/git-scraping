#region

using GitScraping.Application.Bases;

#endregion

namespace GitScraping.Application.Dtos
{
    public class HttpExtractedFileDto : EntityDto
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Sha { get; set; }
        public int Size { get; set; }
        public string Url { get; set; }
    }
}