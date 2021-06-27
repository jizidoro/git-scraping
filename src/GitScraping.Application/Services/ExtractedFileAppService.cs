#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos;
using GitScraping.Application.Filters;
using GitScraping.Application.Interfaces;
using Octokit;

#endregion

namespace GitScraping.Application.Services
{
    public class ExtractedFileAppService : AppService, IExtractedFileAppService
    {
        private readonly IHttpClientHelper _httpClientHelper;

        public ExtractedFileAppService(
            IMapper mapper, IHttpClientHelper httpClientHelper)
            : base(mapper)
        {
            _httpClientHelper = httpClientHelper ?? throw new ArgumentNullException(nameof(HttpClientHelper));
        }


        public async Task<List<ExtractedFileDto>> Listar()
        {
            var repoOwner = "yakkumo";
            var repoName = "git-scraping";
            var path = "/";

            var files = new List<ExtractedFileDto>();

            var productInformation = new ProductHeaderValue("Github-API-Test");
            var credentials = new Credentials("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");
            var client = new GitHubClient(productInformation) {Credentials = credentials};

            await ListContentsOctokit(repoOwner, repoName, path, client, files);
            // await ListContentsCommitOctokit(repoOwner, repoName, client);

            // var httpClientResults = await ListContents(repoOwner, repoName, path);

            return new List<ExtractedFileDto>(files);
        }

        public async Task<IList<HttpExtractedFileDto>> ListContents(string repoOwner, string repoName, string path)
        {
            try
            {
                //var resp = await _httpClientHelper.GetAsync<List<HttpExtractedFileDto>>(
                //    $"repos/{repoOwner}/{repoName}/contents/{path}");

                var resp = await _httpClientHelper.GetAsync<List<HttpExtractedFileDto>>(
                    $"repos/{repoOwner}/{repoName}/stats/code_frequency");

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
            try
            {
                var tipCommit = await client.Repository.GetAllLanguages(repoOwner, repoName);

                var stats = new Dictionary<string, int>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task ListContentsOctokit(string repoOwner, string repoName, string path, GitHubClient client,
            List<ExtractedFileDto> files)
        {
            var contents = await client.Repository.Content.GetAllContents(repoOwner, repoName, path);
            var sourceFiles = contents.Where(x => x.Type != "Dir").Select(x =>
            {
                var dto = new ExtractedFileDto
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


            foreach (var file in sourceFiles)
            {
                var fileContent = await client.Repository.Content.GetAllContents(repoOwner, repoName, file.Path);

                var content = fileContent.FirstOrDefault()?.Content;

                if (content != null)
                {
                    var numberLines = content.Split('\n').Length;
                    file.Lines = numberLines;
                    files.Add(file);
                }
            }


            var dirs = contents.Where(x => x.Type == "Dir");

            foreach (var dir in dirs)
            {
                await ListContentsOctokit(repoOwner, repoName, dir.Path, client, files);
            }
        }
    }
}