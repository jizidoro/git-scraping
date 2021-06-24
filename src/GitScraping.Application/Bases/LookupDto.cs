#region

using GitScraping.Application.Utils;

#endregion

namespace GitScraping.Application.Bases
{
    public class LookupDto : EntityDto, ILookupDto
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}