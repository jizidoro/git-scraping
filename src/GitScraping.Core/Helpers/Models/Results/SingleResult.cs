#region

using System;
using System.Collections.Generic;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Domain.Enums;
using GitScraping.Domain.Interfaces;

#endregion

namespace GitScraping.Core.Helpers.Models.Results
{
    public class SingleResult<TEntity> : ISingleResult<TEntity>
        where TEntity : IEntity
    {
        public SingleResult()
        {
            Codigo = (int) EnumResultadoAcao.Sucesso;
            Sucesso = true;
        }

        public SingleResult(string mensagem)
        {
            Codigo = (int) EnumResultadoAcao.ErroValidacaoNegocio;
            Sucesso = false;
            Mensagem = mensagem;
        }

        public SingleResult(IEnumerable<string> mensagens)
        {
            Codigo = (int) EnumResultadoAcao.ErroValidacaoNegocio;
            Sucesso = false;
            Mensagens = mensagens;
        }


        public SingleResult(int codigo, string mensagem)
        {
            Codigo = codigo;
            Sucesso = false;
            Mensagem = mensagem;
        }

        public SingleResult(Exception ex)
        {
            Codigo = (int) EnumResultadoAcao.ErroServidor;
            Sucesso = false;
        }

        public SingleResult(TEntity data)
        {
            Codigo = data == null ? (int) EnumResultadoAcao.ErroNaoEncontrado : (int) EnumResultadoAcao.Sucesso;
            Sucesso = data != null;
            Data = data;
        }

        public IEnumerable<string> Mensagens { get; set; }
        public string Mensagem { get; set; }

        public int Codigo { get; set; }
        public bool Sucesso { get; set; }
        public TEntity Data { get; set; }
    }
}