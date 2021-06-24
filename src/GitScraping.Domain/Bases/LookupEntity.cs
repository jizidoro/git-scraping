#region

using GitScraping.Domain.Interfaces;

#endregion

namespace GitScraping.Domain.Bases
{
    public class LookupEntity : ILookupEntity
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}