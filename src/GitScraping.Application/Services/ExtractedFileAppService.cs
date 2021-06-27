#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GitScraping.Application.Bases;
using GitScraping.Application.Dtos;
using GitScraping.Application.Interfaces;
using GitScraping.Core.ExtractedFileCore;
using GitScraping.Core.ExtractedFileCore.Usecase;
using GitScraping.Domain.Models;
using Octokit;

#endregion

namespace GitScraping.Application.Services
{
    public class ExtractedFileAppService : AppService, IExtractedFileAppService
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly IProcessFilesUsecase _processFilesUsecase;
        private readonly IGetAllSourceFilesFromRepositoryUsecase _getAllSourceFilesFromRepository;

        public ExtractedFileAppService(
            IMapper mapper, IHttpClientHelper httpClientHelper, IProcessFilesUsecase processFilesUsecase, IGetAllSourceFilesFromRepositoryUsecase getAllSourceFilesFromRepository)
            : base(mapper)
        {
            _httpClientHelper = httpClientHelper ?? throw new ArgumentNullException(nameof(HttpClientHelper));
            _processFilesUsecase = processFilesUsecase;
            _getAllSourceFilesFromRepository = getAllSourceFilesFromRepository;
        }


        public async Task<List<ProcessedFileDto>> GetReportByLanguage(string repositoryOwner, string repoName)
        {
            var gitHubClient = GitHubClientUsecase.Execute();
            var sourceFiles = await _getAllSourceFilesFromRepository.Execute(repositoryOwner, repoName, gitHubClient);

            if (sourceFiles.Any())
            {
                var response = ProcessFiles(sourceFiles);
                return new List<ProcessedFileDto>(response);
            }

            return new List<ProcessedFileDto>();
        }

        private List<ProcessedFileDto> ProcessFiles(List<ExtractedFile> files)
        {
            var result = _processFilesUsecase.Execute(files);
            var response = Mapper.Map<List<ProcessedFileDto>>(result);
            return response;
        }

        
    }
}