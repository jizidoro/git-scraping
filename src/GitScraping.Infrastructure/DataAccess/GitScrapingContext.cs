#region

using GitScraping.Domain.Models;
using GitScraping.Domain.Models.Views;
using GitScraping.Infrastructure.Mappings;
using GitScraping.Infrastructure.Mappings.Views;
using Microsoft.EntityFrameworkCore;

#endregion

namespace GitScraping.Infrastructure.DataAccess
{
    public class GitScrapingContext : DbContext
    {
        private const string JsonPath = "GitScraping.Infrastructure.SeedData";

        public GitScrapingContext(DbContextOptions<GitScrapingContext> options)
            : base(options)
        {
        }

        // Tabelas
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<UsuarioSistema> UsuarioSistemas { get; set; }

        // Views
        public DbSet<VwUsuarioSistemaPermissao> VUsuarioSistemaPermissoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tabelas
            modelBuilder.ApplyConfiguration(new AirplaneConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioSistemaConfiguration());

            // Views
            modelBuilder.ApplyConfiguration(new VwUsuarioSistemaPermissaoConfiguration());
        }
    }
}