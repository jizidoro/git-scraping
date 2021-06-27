#region

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using GitScraping.Application.Dtos;
using GitScraping.Application.Services;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Xunit;

#endregion

namespace GitScraping.UnitTests.Tests
{
    public class HttpClientHelperTest
    {
        public HttpClientHelperTest()
        {
            HttpClientHelperUnderTest = new HttpClientHelper();
        }

        protected HttpClientHelper HttpClientHelperUnderTest { get; }

        /// <summary>
        ///     Weather info by city name test cases are resides.
        /// </summary>
        public class GetAsyncHttpHelper : HttpClientHelperTest
        {
            [Fact]
            public async Task When_GetAsync_Returns_Success_Result()
            {
                //Arrange;
                var result = new List<ExtractedFileDto>
                {
                    new()
                };
                var httpMessageHandler = new Mock<HttpMessageHandler>();
                var fixture = new Fixture();

                // Setup Protected method on HttpMessageHandler mock.
                httpMessageHandler.Protected()
                    .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                        ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>()
                    )
                    .ReturnsAsync((HttpRequestMessage request, CancellationToken token) =>
                    {
                        var response = new HttpResponseMessage();
                        response.StatusCode = HttpStatusCode.OK; //Setting statuscode
                        response.Content =
                            new StringContent(
                                JsonConvert.SerializeObject(result)); // configure your response here
                        response.Content.Headers.ContentType =
                            new MediaTypeHeaderValue("application/json"); //Setting media type for the response
                        return response;
                    });

                var httpClient = new HttpClient(httpMessageHandler.Object);
                httpClient.BaseAddress = fixture.Create<Uri>();

                HttpClientHelperUnderTest.HttpClient =
                    httpClient; //Mocking setting Httphandler object to interface property.

                //Act
                var weatherResult = await HttpClientHelperUnderTest.GetAsync<List<ExtractedFileDto>>(string.Empty);

                // Assert
                Assert.NotNull(weatherResult);
            }
        }
    }
}