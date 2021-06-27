#region

using GitScraping.Domain.Bases;

#endregion

namespace GitScraping.Domain.Models
{
    public class ProcessedFile : Entity
    {
        public string Extension { get; set; }
        public int Count { get; set; }
        public decimal Lines { get; set; }
        public decimal Bytes { get; set; }
    }
}