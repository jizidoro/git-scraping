#region

using System;
using System.Threading.Tasks;
using AutoMapper;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos;
using GitScraping.Application.Filters;
using GitScraping.Application.Interfaces;
using GitScraping.Application.Queries;
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
        [Route("listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var result = await _extractedFileAppService.Listar();
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok(new ExtractedFileDto());
            }
        }
    }
}