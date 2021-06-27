#region

using System;
using System.Threading.Tasks;
using AutoMapper;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos;
using GitScraping.Application.Interfaces;
using GitScraping.WebApi.Bases;
using GitScraping.WebApi.Modules.Common.FeatureFlags;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement.Mvc;

#endregion

namespace GitScraping.WebApi.Controllers.V1.ExtractedFileApi
{
    [FeatureGate(CustomFeature.ExtractedFile)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ExtractedFileController : GitScrapingController
    {
        private readonly IExtractedFileAppService _extractedFileAppService;
        private readonly ILogger<ExtractedFileController> _logger;
        private readonly IMapper _mapper;

        public ExtractedFileController(
            IExtractedFileAppService extractedFileAppService, IMapper mapper, ILogger<ExtractedFileController> logger)
        {
            _extractedFileAppService = extractedFileAppService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetReportByLanguage")]
        public async Task<IActionResult> GetReportByLanguage(string repositoryOwner, string repositoryName)
        {
            try
            {
                var result = await _extractedFileAppService.GetReportByLanguage(repositoryOwner, repositoryName);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new SingleResultDto<ExtractedFileDto>(e));
            }
        }
    }
}