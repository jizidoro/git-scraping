#region

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
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
            var client = new GitHubClient(new ProductHeaderValue("Github-API-Test"));

            ListContentsOctokit(repoOwner, repoName, path, client, files);

            var httpClientResults = await ListContents(repoOwner, repoName, path);

            return new ListResultDto<AirplaneDto>(httpClientResults);
        }

        public async Task<IList<AirplaneDto>> ListContents(string repoOwner, string repoName, string path)
        {
            try
            {
                var resp = await _httpClientHelper.GetAsync<List<AirplaneDto>>(
                    $"repos/{repoOwner}/{repoName}/contents/{path}");

                return resp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async void ListContentsOctokit(string repoOwner, string repoName, string path, GitHubClient client,
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
                ListContentsOctokit(repoOwner, repoName, dir.Path, client, files);
            }
        }
    }
}