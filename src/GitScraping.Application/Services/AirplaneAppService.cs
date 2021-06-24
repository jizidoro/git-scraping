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
using GitScraping.Core.AirplaneCore;
using GitScraping.Core.AirplaneCore.Usecase;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Domain.Models;
using Microsoft.EntityFrameworkCore;

#endregion

namespace GitScraping.Application.Services
{
    public class AirplaneAppService : AppService, IAirplaneAppService
    {
        private readonly AirplaneEditarUsecase _editarAirplaneUsecase;
        private readonly AirplaneExcluirUsecase _excluirAirplaneUsecase;
        private readonly AirplaneIncluirUsecase _incluirAirplaneUsecase;
        private readonly IRepository<Airplane> _repository;

        public AirplaneAppService(IRepository<Airplane> repository,
            AirplaneEditarUsecase editarAirplaneUsecase,
            AirplaneIncluirUsecase incluirAirplaneUsecase,
            AirplaneExcluirUsecase excluirAirplaneUsecase,
            IMapper mapper)
            : base(mapper)
        {
            _repository = repository;
            _editarAirplaneUsecase = editarAirplaneUsecase;
            _incluirAirplaneUsecase = incluirAirplaneUsecase;
            _excluirAirplaneUsecase = excluirAirplaneUsecase;
        }

        public async Task<IPageResultDto<AirplaneDto>> Listar(PaginationFilter paginationFilter = null)
        {
            List<AirplaneDto> lista;
            if (paginationFilter == null)
            {
                lista = await Task.Run(() => _repository.GetAll()
                    .ProjectTo<AirplaneDto>(Mapper.ConfigurationProvider)
                    .ToListAsync());

                return new PageResultDto<AirplaneDto>(lista);
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

            lista = await Task.Run(() => _repository.GetAll().Skip(skip).Take(paginationFilter.PageSize)
                .ProjectTo<AirplaneDto>(Mapper.ConfigurationProvider)
                .ToListAsync());

            return new PageResultDto<AirplaneDto>(lista);
        }

        public async Task<ISingleResultDto<AirplaneDto>> Obter(int id)
        {
            var entity = await _repository.GetById(id);
            var dto = Mapper.Map<AirplaneDto>(entity);
            return new SingleResultDto<AirplaneDto>(dto);
        }

        public async Task<ISingleResultDto<EntityDto>> Incluir(AirplaneIncluirDto dto)
        {
            var validator = new AirplaneIncluirValidation();

            var results = await validator.ValidateAsync(dto);

            if (!results.IsValid)
            {
                var listaErros = results.Errors.Select(x => x.ErrorMessage);
                return new SingleResultDto<EntityDto>(listaErros);
            }

            var evento = Mapper.Map<Airplane>(dto);

            var result = await _incluirAirplaneUsecase.Execute(evento);

            var resultDto = new SingleResultDto<EntityDto>(result);
            resultDto.SetData(result, Mapper);

            return resultDto;
        }

        public async Task<ISingleResultDto<EntityDto>> Editar(AirplaneEditarDto dto)
        {
            var validator = new AirplaneEditarValidation();

            var results = await validator.ValidateAsync(dto);

            if (!results.IsValid)
            {
                var listaErros = results.Errors.Select(x => x.ErrorMessage);
                return new SingleResultDto<EntityDto>(listaErros);
            }

            var evento = Mapper.Map<Airplane>(dto);

            var result = await _editarAirplaneUsecase.Execute(evento);

            var resultDto = new SingleResultDto<EntityDto>(result);
            resultDto.SetData(result, Mapper);

            return resultDto;
        }

        public async Task<ISingleResultDto<EntityDto>> Excluir(int id)
        {
            var result = await _excluirAirplaneUsecase.Execute(id);

            var resultDto = new SingleResultDto<EntityDto>(result);
            resultDto.SetData(result, Mapper);

            return resultDto;
        }
    }
}