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
using GitScraping.Core.ExtractedFileCore;
using GitScraping.Domain.Models;
using Octokit;

#endregion

namespace GitScraping.Application.Services
{
    public class ExtractedFileAppService : AppService, IExtractedFileAppService
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly IProcessFilesUseCaseUsecase _processFilesUseCaseUsecase;

        public ExtractedFileAppService(
            IMapper mapper, IHttpClientHelper httpClientHelper, IProcessFilesUseCaseUsecase processFilesUseCaseUsecase)
            : base(mapper)
        {
            _httpClientHelper = httpClientHelper ?? throw new ArgumentNullException(nameof(HttpClientHelper));
            _processFilesUseCaseUsecase = processFilesUseCaseUsecase;
        }


        public async Task<List<ProcessedFileDto>> Listar()
        {
            var repoOwner = "yakkumo";
            var repoName = "git-scraping";
            var path = "/";

            var files = new List<ExtractedFileDto>();

            var productInformation = new ProductHeaderValue("Github-API-Test");
            var credentials = new Credentials("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");
            var client = new GitHubClient(productInformation) {Credentials = credentials};

            await ListContentsOctokit(repoOwner, repoName, path, client, files);

            var entity = Mapper.Map<List<ExtractedFile>>(files);

            var teste = _processFilesUseCaseUsecase.Execute(entity);

            var result = Mapper.Map<List<ProcessedFileDto>>(teste);

            return new List<ProcessedFileDto>(result);
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