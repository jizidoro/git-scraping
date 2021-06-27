#region

using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using GitScraping.Application.Interfaces;

#endregion

namespace GitScraping.Application.Services
{
    public class HttpClientHelper : IHttpClientHelper
    {
        public HttpClient HttpClient { get; set; }

        public async Task<TResult> GetAsync<TResult>(string requestUri)
        {
            var objResult = default(TResult);

            using var client = GetHttpClient();
            using var response = await client.GetAsync(requestUri);

            if (TryParse(response, out objResult))
            {
                return objResult;
            }

            using var content = response.Content;

            throw new HttpRequestException(response.Content.ReadAsStringAsync().Result);
        }

        private HttpClient GetHttpClient()
        {
            if (HttpClient == null)
            {
                return new HttpClient
                {
                    BaseAddress = new Uri("https://api.github.com"),
                    DefaultRequestHeaders =
                    {
                        {"User-Agent", "Github-API-Test"}
                    }
                };
            }

            return HttpClient;
        }

        private bool TryParse<TResult>(HttpResponseMessage response, out TResult t)
        {
            if (typeof(TResult).IsAssignableFrom(typeof(HttpResponseMessage)))
            {
                t = (TResult) Convert.ChangeType(response, typeof(TResult));
                return true;
            }

            if (response.IsSuccessStatusCode)
            {
                var teste = response.Content.ReadAsStringAsync().Result;

                t = ReadAsAsync<TResult>(response.Content).Result;
                return true;
            }

            t = default;
            return false;
        }

        public static async Task<T> ReadAsAsync<T>(HttpContent content)
        {
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new JsonStringEnumConverter());

            return await JsonSerializer.DeserializeAsync<T>(await content.ReadAsStreamAsync(), options);
        }
    }
}