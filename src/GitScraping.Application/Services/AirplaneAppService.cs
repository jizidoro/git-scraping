#region

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos.AirplaneDtos;
using GitScraping.Application.Filters;
using GitScraping.Application.Interfaces;
using Octokit;

namespace GitScraping.Application.Services
{
    public class AirplaneAppService : AppService, IAirplaneAppService
    {
        private readonly IHttpClientHelper _httpClientHelper;

        public AirplaneAppService(
            IMapper mapper, IHttpClientHelper httpClientHelper)
            : base(mapper)
        {
            _httpClientHelper = httpClientHelper ?? throw new ArgumentNullException(nameof(HttpClientHelper));
        }


        public async Task<ListResultDto<AirplaneDto>> Listar(PaginationFilter paginationFilter = null)
        {
            List<AirplaneDto> lista = new();

            var repoOwner = "yakkumo";
            var repoName = "git-scraping";
            var path = "/";

            var files = new List<AirplaneDto>();

            var productInformation = new ProductHeaderValue("Github-API-Test");
            var credentials = new Credentials("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");
            var client = new GitHubClient(productInformation) {Credentials = credentials};

            // await ListContentsOctokit(repoOwner, repoName, path, client, files);
            await ListContentsCommitOctokit(repoOwner, repoName, client);

            var httpClientResults = await ListContents(repoOwner, repoName, path);

            return new ListResultDto<AirplaneDto>(lista);
        }

        public async Task<IList<HttpAirplaneDto>> ListContents(string repoOwner, string repoName, string path)
        {
            try
            {
                var resp = await _httpClientHelper.GetAsync<List<HttpAirplaneDto>>(
                    $"repos/{repoOwner}/{repoName}/contents/{path}");

                return resp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task ListContentsCommitOctokit(string repoOwner, string repoName, GitHubClient client)
        {
            var tipCommit = await client.Repository.Commit.Get(repoOwner, repoName, "master");
            var allPaths = tipCommit.Files.Select(f => f.Filename);

            var stats = new Dictionary<string, int>();
        }

        public async Task ListContentsOctokit(string repoOwner, string repoName, string path, GitHubClient client,
            List<AirplaneDto> files)
        {
            var contents = await client.Repository.Content.GetAllContents(repoOwner, repoName, path);
            var sourceFiles = contents.Where(x => x.Type != "Dir").Select(x =>
            {
                var dto = new AirplaneDto
                {
                    Name = x.Name,
                    Path = x.Path,
                    Sha = x.Sha,
                    Type = x.Type,
                    Url = x.Url,
                    Size = x.Size
                };
                return dto;
            });

            files.AddRange(sourceFiles);

            var dirs = contents.Where(x => x.Type == "Dir");

            foreach (var dir in dirs)
            {
                await ListContentsOctokit(repoOwner, repoName, dir.Path, client, files);
            }
        }
    }
}