#region

using System.Net.Http;
using System.Threading.Tasks;

#endregion

namespace GitScraping.Application.Interfaces
{
    public interface IHttpClientHelper
    {
        HttpClient HttpClient { get; set; }
        Task<TResult> GetAsync<TResult>(string requestUri);
    }
}