using System;
using System.IO;
using System.Threading.Tasks;
using Modulbank.FileStorage.BL.Contracts.File;
using Modulbank.FileStorage.BL.Contracts.File.Models;
using Modulbank.FileStorage.BL.Contracts.Storage;
using Modulbank.FileStorage.StorageServices.Contracts.File;

namespace Modulbank.FileStorage.BL.Files.Handlers
{
    public class GetFileHandler
    {
        private readonly IFileService _fileService;
        private readonly IFileStorageHelper _fileStorageHelper;
        public GetFileHandler(IFileService fileService, IFileStorageHelper fileStorageHelper)
        {
            _fileService = fileService;
            _fileStorageHelper = fileStorageHelper;
        }

        public async Task<(Stream, FileModel)> Get(Guid fileId)
        {
            var fileObj = await _fileService.GetFile(fileId);

            Stream stream = await _fileStorageHelper.GetFileAsync(fileId, fileObj.Bucket);

            return (stream, fileObj);
        }
    }
}
