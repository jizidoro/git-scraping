#region

using GitScraping.Application.Interfaces;
using GitScraping.Application.Services;
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
            #region Airplane

            // Application - Services
            services.AddScoped<IExtractedFileAppService, ExtractedFileAppService>();
            services.AddScoped<IHttpClientHelper, HttpClientHelper>();

            #endregion


            return services;
        }
    }
}