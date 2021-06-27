#region

using GitScraping.Application.Interfaces;
using GitScraping.Application.Services;
using GitScraping.Core.ExtractedFileCore;
using GitScraping.Core.ExtractedFileCore.Usecase;
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
            services.AddScoped<IExtractedFileAppService, ExtractedFileAppService>();
            services.AddScoped<IProcessFilesUsecase, ProcessFilesUsecase>();
            services.AddScoped<IGetContentsOctokitUsecase, GetContentsOctokitUsecase>();
            services.AddScoped<IGetAllSourceFilesFromRepositoryUsecase, GetAllSourceFilesFromRepositoryUsecase>();
            services.AddScoped<IHttpClientHelper, HttpClientHelper>();

            return services;
        }
    }
}