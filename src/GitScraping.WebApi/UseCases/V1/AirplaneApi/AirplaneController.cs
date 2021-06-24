#region

using System;
using System.Threading.Tasks;
using AutoMapper;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos.AirplaneDtos;
using GitScraping.Application.Filters;
using GitScraping.Application.Interfaces;
using GitScraping.Application.Queries;
using GitScraping.WebApi.Bases;
using GitScraping.WebApi.Modules.Common.FeatureFlags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement.Mvc;

#endregion

namespace GitScraping.WebApi.UseCases.V1.AirplaneApi
{
    [FeatureGate(CustomFeature.Airplane)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AirplaneController : GitScrapingController
    {
        private readonly IAirplaneAppService _airplaneAppService;
        private readonly ILogger<AirplaneController> _logger;
        private readonly IMapper _mapper;

        public AirplaneController(
            IAirplaneAppService airplaneAppService, IMapper mapper, ILogger<AirplaneController> logger)
        {
            _airplaneAppService = airplaneAppService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> Listar([FromQuery] PaginationQuery? paginationQuery)
        {
            try
            {
                PaginationFilter? paginationFilter = null;
                if (paginationQuery != null)
                {
                    paginationFilter = _mapper.Map<PaginationQuery, PaginationFilter>(paginationQuery);
                }

                var result = await _airplaneAppService.Listar(paginationFilter);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new SingleResultDto<AirplaneDto>(e));
            }
        }
        
    }
}