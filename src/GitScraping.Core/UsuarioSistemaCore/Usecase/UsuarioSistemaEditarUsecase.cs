#region

using System;
using System.Threading.Tasks;
using GitScraping.Core.Helpers.Bases;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Models.Results;
using GitScraping.Core.UsuarioSistemaCore.Validation;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.UsuarioSistemaCore.Usecase
{
    public class UsuarioSistemaEditarUsecase : Service
    {
        private readonly IUsuarioSistemaRepository _repository;
        private readonly UsuarioSistemaValidarEditar _usuarioSistemaValidarEditar;

        public UsuarioSistemaEditarUsecase(IUsuarioSistemaRepository repository,
            UsuarioSistemaValidarEditar usuarioSistemaValidarEditar, IUnitOfWork uow)
            : base(uow)
        {
            _repository = repository;
            _usuarioSistemaValidarEditar = usuarioSistemaValidarEditar;
        }

        public async Task<ISingleResult<UsuarioSistema>> Execute(UsuarioSistema entity)
        {
            try
            {
                var isValid = ValidarEntidade(entity);
                if (!isValid.Sucesso)
                {
                    return isValid;
                }

                var result = await _usuarioSistemaValidarEditar.Execute(entity);
                if (!result.Sucesso) return result;

                var obj = result.Data;

                HydrateValues(obj, entity);

                _repository.Update(obj);

                var sucesso = await Commit();
            }
            catch (Exception ex)
            {
                return new SingleResult<UsuarioSistema>(ex);
            }

            return new EditarResult<UsuarioSistema>();
        }

        private void HydrateValues(UsuarioSistema target, UsuarioSistema source)
        {
            target.Nome = source.Nome;
            target.Email = source.Email;
            target.Matricula = source.Matricula;
            target.Situacao = source.Situacao;
        }
    }
}