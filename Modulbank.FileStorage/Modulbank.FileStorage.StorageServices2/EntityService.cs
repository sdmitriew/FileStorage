using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using Modulbank.FileStorage.BL.Contracts;
using Modulbank.FileStorage.BL.Contracts.File;
using Modulbank.FileStorage.StorageServices.Contracts.Core;
using Modulbank.FileStorage.StorageServices.Contracts.File;
using Modulbank.FileStorage.StorageServices.Contracts.Mappers;

namespace Modulbank.FileStorage.StorageServices
{
    public class ConnectedEntityService: IConnectedEntityService
    {
        private readonly FileStorageDb _storage;
        private readonly ConnectedEntityMapper _mapper;

        public ConnectedEntityService(FileStorageDb storage, ConnectedEntityMapper mapper)
        {
            _storage = storage;
            _mapper = mapper;
        }

        public async Task AttachFileToEntity(ConnectedEntityModel model)
        {
            var dbObj = _mapper.Map(model);
            await _storage.InsertAsync(dbObj);
        }

        
    }
}
