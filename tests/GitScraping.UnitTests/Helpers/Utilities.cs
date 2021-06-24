#region

using System;
using System.Reflection;
using GitScraping.Domain.Models;
using GitScraping.Infrastructure.DataAccess;
using GitScraping.Infrastructure.Extensions;

#endregion

namespace GitScraping.UnitTests.Helpers
{
    public static class Utilities
    {
        private const string JsonPath = "GitScraping.Infrastructure.SeedData";

        #region DadosIniciais

        public static void InitializeDbForTests(GitScrapingContext db)
        {
            try
            {
                var assembly = Assembly.GetAssembly(typeof(JsonUtilities));

                if (assembly is not null)
                {
                    db.Airplanes.AddRange(
                        JsonUtilities.GetListFromJson<Airplane>(
                            assembly.GetManifestResourceStream($"{JsonPath}.airplane.json")));

                    db.UsuarioSistemas.AddRange(
                        JsonUtilities.GetListFromJson<UsuarioSistema>(
                            assembly.GetManifestResourceStream($"{JsonPath}.usuarioSistema.json")));
                }

                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion
    }
}