#region

using System.Collections.Generic;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.ExtractedFileCore
{
    public interface IProcessFilesUseCaseUsecase
    {
        List<ProcessedFile> Execute(List<ExtractedFile> extractedFiles);
    }
}