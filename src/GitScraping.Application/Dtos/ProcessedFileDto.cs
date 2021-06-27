#region

using GitScraping.Application.Bases;

#endregion

namespace GitScraping.Application.Dtos
{
    public class ProcessedFileDto : EntityDto
    {
        public string Extension { get; set; }
        public int Count { get; set; }
        public decimal Lines { get; set; }
        public decimal Bytes { get; set; }
    }
}