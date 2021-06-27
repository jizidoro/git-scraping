#region

using System.Collections.Generic;
using System.Linq;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.ExtractedFileCore.Usecase
{
    public class ProcessFilesUsecase : IProcessFilesUsecase
    {
        public List<ProcessedFile> Execute(List<ExtractedFile> extractedFiles)
        {
            GetFileExtension(extractedFiles);
            var oto = extractedFiles.GroupBy(x => x.Extension).Select(group => new ProcessedFile
            {
                Extension = group.Key,
                Count = group.Count(),
                Lines = group.Sum(x => x.Lines),
                Bytes = group.Sum(x => x.Size)
            });

            var processedFiles = oto as ProcessedFile[] ?? oto.ToArray();

            return processedFiles.ToList();
        }

        private void GetFileExtension(List<ExtractedFile> extractedFiles)
        {
            foreach (var file in extractedFiles)
            {
                var extension = file.Name.Split('.');
                file.Extension = extension.LastOrDefault();
            }
        }
    }
}