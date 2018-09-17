using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;
using Modulbank.FileStorage.BL.Contracts.File;
using Modulbank.FileStorage.BL.Contracts.File.Models;
using Modulbank.FileStorage.StorageServices.Contracts.Core;
using Modulbank.FileStorage.StorageServices.Contracts.Entities;
using Modulbank.FileStorage.StorageServices.Contracts.File;
using Modulbank.FileStorage.StorageServices.Contracts.Mappers;

namespace Modulbank.FileStorage.StorageServices
{
    public class FileService : IFileService
    {
        private readonly FileStorageDb _storage;
        private readonly FileMapper _mapper;

        public FileService(FileStorageDb storage, FileMapper mapper)
        {
            _storage = storage;
            _mapper = mapper;
        }

        public async Task AddFile(FileModel file)
        {
            var dbObj = _mapper.Map(file);
            await _storage.InsertAsync(dbObj);
        }
        
        public async Task<FileModel> GetFile(Guid fileId)
        {
            var entity = await _storage.File.Where(p => p.Id == fileId).FirstOrDefaultAsync();
            return _mapper.Map(entity);
        }
    }
}
