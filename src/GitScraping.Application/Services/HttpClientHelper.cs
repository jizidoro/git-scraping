using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using GitScraping.Application.Dtos.AirplaneDtos;
using GitScraping.Application.Interfaces;

namespace GitScraping.Application.Services
{
    public class HttpClientHelper : IHttpClientHelper
    {
        public HttpClient HttpClient { get; set; }

        public async Task<TResult> GetAsync<TResult>(string requestUri)
        {
            TResult objResult = default(TResult);

            using var client = this.GetHttpClient();
            using var response = await client.GetAsync(requestUri);

            if (TryParse<TResult>(response, out objResult))
            {
                return objResult;
            }

            using HttpContent content = response.Content;

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
                t = ReadAsAsync<TResult>(response.Content).Result;
                return true;
            }

            t = default(TResult);
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