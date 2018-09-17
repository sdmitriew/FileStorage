using System;
using System.Collections.Generic;
using System.Text;

namespace Modulbank.FileStorage.BL.Contracts
{
    public class ConnectedEntityModel
    {
        public Guid ConnectedEntityId { get; set; }
        public Guid FileId { get; set; }
        public string SolutionName { get; set; } //Имя решения (БГ, портал...)
    }
}
