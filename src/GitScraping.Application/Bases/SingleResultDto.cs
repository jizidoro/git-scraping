#region

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GitScraping.Application.Utils;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Messages;
using GitScraping.Domain.Bases;
using GitScraping.Domain.Enums;
using GitScraping.Domain.Utils;

#endregion

namespace GitScraping.Application.Bases
{
    public class SingleResultDto<TDto> : ResultDto, ISingleResultDto<TDto>
        where TDto : Dto
    {
        public SingleResultDto(TDto data)
        {
            Codigo = data == null ? (int) EnumResultadoAcao.ErroNaoEncontrado : (int) EnumResultadoAcao.Sucesso;
            Sucesso = data != null;
            Data = data;
        }

        public SingleResultDto()
        {
            Codigo = (int) EnumResultadoAcao.ErroNaoEncontrado;
            Sucesso = false;
            Data = null;
        }

        public SingleResultDto(SecurityResult erroSecurity)
        {
            Codigo = erroSecurity.Code;
            Sucesso = false;
            Data = null;
        }


        public SingleResultDto(Exception ex)
        {
            Codigo = (int) EnumResultadoAcao.ErroServidor;
            Sucesso = false;
        }

        public SingleResultDto(IResult result)
        {
            Codigo = result.Codigo;
            Sucesso = result.Sucesso;
        }

        public SingleResultDto(int codigo, bool sucesso)
        {
            Codigo = codigo;
            Sucesso = sucesso;
        }

        public TDto Data { get; private set; }

        public void SetData<TEntity>(ISingleResult<TEntity> result, IMapper mapper)
            where TEntity : Entity
        {
            Data = mapper.Map<TDto>(result.Data);
        }
    }
}