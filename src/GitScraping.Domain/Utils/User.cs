#region

using System.Collections.Generic;

#endregion

namespace GitScraping.Domain.Utils
{
    public class User
    {
        public string Chave { get; set; }
        public string Nomeario { get; set; }
        public string Token { get; set; }
        public IList<string> Papeis { get; set; }
    }
}