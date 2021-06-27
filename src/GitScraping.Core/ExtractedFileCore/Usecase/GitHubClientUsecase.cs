#region

using System;
using System.Collections.Generic;
using System.Linq;
using GitScraping.Domain.Models;
using Octokit;

#endregion

namespace GitScraping.Core.ExtractedFileCore.Usecase
{
    public class GitHubClientUsecase
    {
        public static GitHubClient Execute()
        {
            var value = Environment.GetEnvironmentVariable("git-credential");
            var productInformation = new ProductHeaderValue("Github-API-Test");
            var credentials = new Credentials(value);
            var gitHubClient = new GitHubClient(productInformation) { Credentials = credentials };
            return gitHubClient;
        }


    }
}