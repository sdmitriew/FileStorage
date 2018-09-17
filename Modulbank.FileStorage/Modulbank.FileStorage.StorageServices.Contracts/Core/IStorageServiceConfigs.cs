using System;
using System.Collections.Generic;
using System.Text;

namespace Modulbank.FileStorage.StorageServices.Contracts.Core
{
    public interface IStorageServiceConfigs
    {
        string ConnectionString { get; }
    }
}
