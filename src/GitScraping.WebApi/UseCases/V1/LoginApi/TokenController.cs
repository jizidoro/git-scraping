#region

using System.Threading.Tasks;
using GitScraping.Application.Dtos;
using GitScraping.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace GitScraping.WebApi.UseCases.V1.LoginApi
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAutenticacaoAppService _autenticacaoAppService;

        public TokenController(
            IAutenticacaoAppService autenticacaoAppService
        )
        {
            _autenticacaoAppService = autenticacaoAppService;
        }


        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> Token([FromBody] AutenticacaoDto dto)
        {
            var result = await _autenticacaoAppService.GerarTokenLoginUsecase(dto);

            return Ok(result);
        }
    }
}