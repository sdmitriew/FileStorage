using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Modulbank.FileStorage.BL.Contracts.Storage
{
    public interface IFileStorageHelper
    {
        Task<Stream> GetFileAsync(Guid objectName, string bucket);
        Task<Guid> SaveFile(Stream stream, string bucket);
    }
}
