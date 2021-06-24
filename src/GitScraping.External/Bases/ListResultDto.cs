#region

using System.Collections.Generic;
using GitScraping.Domain.Enums;
using GitScraping.External.Utils;

#endregion

namespace GitScraping.External.Bases
{
    public class ListResultDto<T> : ResultDto, IListResultDto<T>
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

        public IList<T> Data { get; set; }
    }
}