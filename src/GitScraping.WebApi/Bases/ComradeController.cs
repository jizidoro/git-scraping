#region

using System.Linq;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace GitScraping.WebApi.Bases
{
    public class GitScrapingController : ControllerBase
    {
        [NonAction]
        protected int? GetUserId()
        {
            return User != null ? int.Parse(User.Claims.First(i => i.Type == "Chave").Value) : 0;
        }
    }
}