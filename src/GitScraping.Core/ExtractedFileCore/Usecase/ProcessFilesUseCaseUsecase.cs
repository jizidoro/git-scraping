#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitScraping.Core.Helpers.Interfaces;
using GitScraping.Core.Helpers.Messages;
using GitScraping.Core.Helpers.Models.Results;
using GitScraping.Domain.Models;

#endregion

namespace GitScraping.Core.ExtractedFileCore.Usecase
{
    public class ProcessFilesUseCaseUsecase
    {
        public ProcessFilesUseCaseUsecase()
        {
        }

        public async Task<ISingleResult<ExtractedFile>> Execute(List<ExtractedFile> entity)
        {
            try
            {
                
            }
            catch (Exception)
            {
                return new SingleResult<ExtractedFile>(BusinessMessage.MSG001);
            }

            return new SingleResult<ExtractedFile>(new ExtractedFile());
        }
    }
}