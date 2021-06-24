#region

using GitScraping.Core.AirplaneCore;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.UsuarioSistemaCore;
using GitScraping.Core.Views.VBaUsuPermissaoCore;
using GitScraping.Infrastructure.DataAccess;
using GitScraping.Infrastructure.Repositories;
using GitScraping.Infrastructure.Repositories.Views;
using GitScraping.WebApi.Modules.Common.FeatureFlags;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

#endregion

namespace GitScraping.WebApi.Modules
{
    /// <summary>
    ///     Persistence Extensions.
    /// </summary>
    public static class EntityRepositoryExtensions
    {
        /// <summary>
        ///     Add Persistence dependencies varying on configuration.
        /// </summary>
        public static IServiceCollection AddEntityRepository(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            IFeatureManager featureManager = services
                .BuildServiceProvider()
                .GetRequiredService<IFeatureManager>();

            var isEnabled = featureManager
                .IsEnabledAsync(nameof(CustomFeature.SqlServer))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            if (isEnabled)
            {
                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddScoped<IAirplaneRepository, AirplaneRepository>();
                services.AddScoped<IUsuarioSistemaRepository, UsuarioSistemaRepository>();
                services.AddScoped<IVwUsuarioSistemaPermissaoRepository, VwUsuarioSistemaPermissaoRepository>();
            }

            return services;
        }
    }
}