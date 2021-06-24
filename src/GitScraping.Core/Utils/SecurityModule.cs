#region

using System;
using GitScraping.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

#endregion

namespace GitScraping.Core.Utils
{
    public static class SecurityModule
    {
        public static void RegisterPolicies(AuthorizationOptions options)
        {
            foreach (EnumRecursos recurso in Enum.GetValues(typeof(EnumRecursos)))
                options.AddPolicy(recurso.ToString(), policy =>
                    policy.RequireClaim("Recurso", recurso.ToString()));
        }
    }
}