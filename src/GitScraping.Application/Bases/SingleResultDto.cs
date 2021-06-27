#region

using System;
using AutoMapper;
using GitScraping.Application.Utils;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Domain.Bases;
using GitScraping.Domain.Enums;

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

        public SingleResultDto(Exception ex)
        {
            Codigo = (int) EnumResultadoAcao.ErroServidor;
            Sucesso = false;
            Mensagem = ex.Message;
        }

        public TDto Data { get; private set; }

        public void SetData<TEntity>(ISingleResult<TEntity> result, IMapper mapper)
            where TEntity : Entity
        {
            Data = mapper.Map<TDto>(result.Data);
        }
    }
}