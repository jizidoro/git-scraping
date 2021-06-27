#region

using System.Collections.Generic;
using GitScraping.Application.Utils;
using GitScraping.Domain.Enums;

#endregion

namespace GitScraping.Application.Bases
{
    public class ListResultDto<T> : ResultDto, IListResultDto<T>
        where T : Dto
    {
        public ListResultDto()
        {
        }

        public ListResultDto(IList<T> data)
        {
            Data = data;
            Codigo = data == null ? (int) EnumResultadoAcao.ErroNaoEncontrado : (int) EnumResultadoAcao.Sucesso;
            Sucesso = data != null;
        }

        public ListResultDto(int codigo)
        {
            Codigo = codigo;
            Sucesso = false;
        }

        public IList<T> Data { get; set; }
    }
}