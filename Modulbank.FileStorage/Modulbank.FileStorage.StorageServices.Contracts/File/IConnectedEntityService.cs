using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Modulbank.FileStorage.BL.Contracts;
using Modulbank.FileStorage.BL.Contracts.File;

namespace Modulbank.FileStorage.StorageServices.Contracts.File
{
    public interface IConnectedEntityService
    {
        Task AttachFileToEntity(ConnectedEntityModel model);
    }
}
