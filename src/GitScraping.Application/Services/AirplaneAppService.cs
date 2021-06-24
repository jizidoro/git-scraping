#region

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos.AirplaneDtos;
using GitScraping.Application.Filters;
using GitScraping.Application.Interfaces;
using GitScraping.Application.Utils;
using GitScraping.Application.Validations.AirplaneValitation;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Domain.Models;
using Microsoft.EntityFrameworkCore;

#endregion

namespace GitScraping.Application.Services
{
    public class AirplaneAppService : AppService, IAirplaneAppService
    {
        public AirplaneAppService(
            IMapper mapper)
            : base(mapper)
        {
        }

        public async Task<IPageResultDto<AirplaneDto>> Listar(PaginationFilter paginationFilter = null)
        {
            List<AirplaneDto> lista = new();

            return new PageResultDto<AirplaneDto>(lista);
        }
        
    }
}