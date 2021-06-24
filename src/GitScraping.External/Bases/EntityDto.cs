#region

using GitScraping.External.Utils;

#endregion

namespace GitScraping.External.Bases
{
    public class EntityDto : Dto, IEntityDto
    {
        public int Id { get; set; }
    }
}