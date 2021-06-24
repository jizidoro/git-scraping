#region

using System;
using System.Threading.Tasks;
using GitScraping.Core.AirplaneCore.Validation;
using GitScraping.Core.Helpers.Bases;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Messages;
using GitScraping.Core.Helpers.Models.Results;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.AirplaneCore.Usecase
{
    public class AirplaneExcluirUsecase : Service
    {
        private readonly AirplaneValidarExcluir _airplaneValidarExcluir;
        private readonly IAirplaneRepository _repository;

        public AirplaneExcluirUsecase(IAirplaneRepository repository, AirplaneValidarExcluir airplaneValidarExcluir,
            IUnitOfWork uow)
            : base(uow)
        {
            _repository = repository;
            _airplaneValidarExcluir = airplaneValidarExcluir;
        }

        public async Task<ISingleResult<Airplane>> Execute(int id)
        {
            try
            {
                var validacao = await _airplaneValidarExcluir.Execute(id);
                if (!validacao.Sucesso) return validacao;

                _repository.Remove(id);

                var sucesso = await Commit();
            }
            catch (Exception)
            {
                return new SingleResult<Airplane>(MensagensNegocio.MSG07);
            }

            return new ExcluirResult<Airplane>();
        }
    }
}