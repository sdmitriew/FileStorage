using System;
using System.Collections.Generic;
using System.Text;
using Modulbank.FileStorage.BL.Contracts;
using Modulbank.FileStorage.StorageServices.Contracts.Core;

namespace Modulbank.FileStorage.BL.Core
{
    public class AppSettingsModel : IStorageServiceConfigs, IBusinessLogicConfigs
    {
        public string MinioHost { set; get; }
        public string MinioAccessKey { set; get; }
        public string MinioSecretKey { set; get; }
        public string ConnectionString { get; set; }
    }
}
