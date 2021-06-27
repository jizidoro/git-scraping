using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using GitScraping.Application.Dtos.AirplaneDtos;
using GitScraping.Application.Services;
using Moq;
using Moq.Protected;
using Xunit;

namespace GitScraping.UnitTests.Tests
{
    public class HttpClientHelperTest
    {
        protected HttpClientHelper HttpClientHelperUnderTest { get; }

        public HttpClientHelperTest()
        {
            HttpClientHelperUnderTest = new HttpClientHelper();
        }

        /// <summary>
        /// Weather info by city name test cases are resides.
        /// </summary>
        public class GetAsyncHttpHelper : HttpClientHelperTest
        {
            [Fact]
            public async Task When_GetAsync_Returns_Success_Result()
            {
                //Arrange;
                var result = new List<AirplaneDto>()
                {
                    new AirplaneDto() { }
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
                        HttpResponseMessage response = new HttpResponseMessage();
                        response.StatusCode = System.Net.HttpStatusCode.OK; //Setting statuscode
                        response.Content =
                            new StringContent(
                                Newtonsoft.Json.JsonConvert.SerializeObject(result)); // configure your response here
                        response.Content.Headers.ContentType =
                            new MediaTypeHeaderValue("application/json"); //Setting media type for the response
                        return response;
                    });

                var httpClient = new HttpClient(httpMessageHandler.Object);
                httpClient.BaseAddress = fixture.Create<Uri>();

                HttpClientHelperUnderTest.HttpClient =
                    httpClient; //Mocking setting Httphandler object to interface property.

                //Act
                var weatherResult = await HttpClientHelperUnderTest.GetAsync<List<AirplaneDto>>(string.Empty);

                // Assert
                Assert.NotNull(weatherResult);
            }
        }
    }
}