using System.Net.Http;
using System.Threading.Tasks;

namespace GitScraping.Application.Interfaces
{

    public interface IHttpClientHelper
    {
        Task<TResult> GetAsync<TResult>(string requestUri);
       
        HttpClient HttpClient { get; set; }

    }

}
