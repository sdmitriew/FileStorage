using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Modulbank.FileStorage.BL.Contracts.File;
using Modulbank.FileStorage.BL.Contracts.File.Models;

namespace Modulbank.FileStorage.StorageServices.Contracts.File
{
    public interface IFileService
    {
        Task<FileModel> GetFile(Guid fileId);
        Task AddFile(FileModel file);
    }
}
