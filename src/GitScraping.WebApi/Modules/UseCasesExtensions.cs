#region

using GitScraping.Application.Interfaces;
using GitScraping.Application.Services;
using GitScraping.Core.AirplaneCore.Usecase;
using GitScraping.Core.AirplaneCore.Validation;
using GitScraping.Core.SecurityCore.Usecase;
using GitScraping.Core.SecurityCore.Validation;
using GitScraping.Core.UsuarioSistemaCore.Usecase;
using GitScraping.Core.UsuarioSistemaCore.Validation;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace GitScraping.WebApi.Modules
{
    /// <summary>
    ///     Adds Use Cases classes.
    /// </summary>
    public static class UseCasesExtensions
    {
        /// <summary>
        ///     Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            #region Autenticacao

            services.AddScoped<IAutenticacaoAppService, AutenticacaoAppService>();

            #endregion

            #region Airplane

            // Application - Services
            services.AddScoped<IAirplaneAppService, AirplaneAppService>();

            // Core - Usecases
            services.AddScoped<AirplaneEditarUsecase>();
            services.AddScoped<AirplaneIncluirUsecase>();
            services.AddScoped<AirplaneExcluirUsecase>();

            // Core - Validations
            services.AddScoped<AirplaneValidarEditar>();
            services.AddScoped<AirplaneValidarExcluir>();
            services.AddScoped<AirplaneValidarIncluir>();
            services.AddScoped<AirplaneValidarCodigoRepetido>();

            #endregion

            #region UsuarioSistema

            // Application - Services
            services.AddScoped<IUsuarioSistemaAppService, UsuarioSistemaAppService>();

            // Core - Usecases
            services.AddScoped<AtualizarSenhaExpiradaUsecase>();
            services.AddScoped<GerarTokenLoginUsecase>();
            services.AddScoped<EsquecerSenhaUsecase>();
            services.AddScoped<UsuarioSistemaValidarEsquecerSenha>();
            services.AddScoped<UsuarioSistemaValidarSenha>();
            services.AddScoped<UsuarioSistemaEditarUsecase>();
            services.AddScoped<UsuarioSistemaIncluirUsecase>();
            services.AddScoped<UsuarioSistemaExcluirUsecase>();

            // Core - Validations
            services.AddScoped<UsuarioSistemaValidarEditar>();
            services.AddScoped<UsuarioSistemaValidarExcluir>();
            services.AddScoped<UsuarioSistemaValidarIncluir>();

            #endregion

            return services;
        }
    }
}