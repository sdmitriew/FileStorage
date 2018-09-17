using System;
using System.Collections.Generic;
using System.Text;

namespace Modulbank.FileStorage.BL.Contracts
{
    public interface IBusinessLogicConfigs
    {
        string MinioHost { get; }
        string MinioAccessKey { get; }
        string MinioSecretKey { get; }
    }
}
