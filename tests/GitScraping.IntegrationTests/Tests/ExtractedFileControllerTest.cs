using System;
using System.Collections.Generic;
using GitScraping.Application.Bases;
using GitScraping.Application.Interfaces;
using GitScraping.WebApi.Controllers.V1.ExtractedFileApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using GitScraping.Application.Dtos;
using GitScraping.Application.Services;
using GitScraping.Core.ExtractedFileCore;
using GitScraping.Core.ExtractedFileCore.Usecase;
using GitScraping.UnitTests.Helpers;
using Xunit;

namespace GitScraping.IntegrationTests.Tests
{
    public class ExtractedFileControllerTest
    {
        protected ExtractedFileController ControllerUnderTest { get; }
        protected Mock<ILogger<ExtractedFileController>> LoggerMock { get; }
        protected ExtractedFileAppService ExtractedFileAppServiceMock { get; }

        public ExtractedFileControllerTest()
        {
            var mapper = MapperHelper.ConfigMapper();
            LoggerMock = new Mock<ILogger<ExtractedFileController>>();
            var processFilesUsecase = new ProcessFilesUsecase();
            var getContentsOctokitUsecase = new GetContentsOctokitUsecase();
            var getAllSourceFilesFromRepositoryUsecase =
                new GetAllSourceFilesFromRepositoryUsecase(getContentsOctokitUsecase);
            ExtractedFileAppServiceMock =
                new ExtractedFileAppService(mapper, processFilesUsecase, getAllSourceFilesFromRepositoryUsecase);

            ControllerUnderTest = new ExtractedFileController(ExtractedFileAppServiceMock, LoggerMock.Object)
            {
                ControllerContext = {HttpContext = new DefaultHttpContext()}
            };
        }

        [Fact]
        public async Task GetReportByLanguage()
        {
            // Arrange;

            // Act 
            var result = await ControllerUnderTest.GetReportByLanguage("yakkumo", "git-scraping");

            // Assert
            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as List<ProcessedFileDto>;
                Assert.NotNull(actualResultValue);
            }
        }

        [Fact]
        public async Task GetReportByLanguage_Error()
        {
            // Arrange;

            // Act 
            var result = await ControllerUnderTest.GetReportByLanguage("", "");

            // Assert
            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
                Assert.NotNull(actualResultValue);
            }
        }
    }
}