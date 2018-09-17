using System;
using System.Collections.Generic;
using System.Text;
using LinqToDB;
using LinqToDB.DataProvider.PostgreSQL;
using LinqToDB.DataProvider.SqlServer;
using Modulbank.FileStorage.StorageServices.Contracts.Entities;

namespace Modulbank.FileStorage.StorageServices.Contracts.Core
{
    public class FileStorageDb : LinqToDB.Data.DataConnection
    {
        public FileStorageDb(IStorageServiceConfigs conf) : base(ProviderName.PostgreSQL95, conf.ConnectionString)
        {
            
        }

        public ITable<FileEntity> File => GetTable<FileEntity>();
        public ITable<ConnectedEntity> ConnectedEntity => GetTable<ConnectedEntity>();
    }
}
