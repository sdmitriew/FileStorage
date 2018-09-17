using System;
using System.IO;
using System.Threading.Tasks;
using Modulbank.FileStorage.BL.Contracts.File;
using Modulbank.FileStorage.BL.Contracts.File.Helpers;
using Modulbank.FileStorage.BL.Contracts.File.Models;
using Modulbank.FileStorage.BL.Contracts.Storage;
using Modulbank.FileStorage.Dto.Request;
using Modulbank.FileStorage.StorageServices.Contracts.File;

namespace Modulbank.FileStorage.BL.Files.Handlers
{
    public class AddFileHandler
    {
        private readonly IFileService _fileService;
        private readonly IFileStorageHelper _fileStorageHelper;
        private readonly IFileHelper _fileHelper;
        
        public AddFileHandler(IFileService fileService, IFileStorageHelper fileStorageHelper, IFileHelper fileHelper)
        {
            _fileService = fileService;
            _fileStorageHelper = fileStorageHelper;
            _fileHelper = fileHelper;
        }

        public async Task<Guid> Save(Stream input, MetaDataRequest request, string fileName, string contentType, string serviceName)
        {
            var obj = await _fileStorageHelper.SaveFile(input, serviceName);
            await _fileService.AddFile(new FileModel()
            {
                ContentType = _fileHelper.DetectMimeType(request?.FileName ?? fileName),
                FileName = request?.FileName ?? fileName,
                Bucket = serviceName,
                Created = DateTime.Today,
                Id = obj
            });
            return obj;
        }
    }
}
