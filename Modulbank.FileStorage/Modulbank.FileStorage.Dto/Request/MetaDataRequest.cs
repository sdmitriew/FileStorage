using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace Modulbank.FileStorage.Dto.Request
{
    public class MetaDataRequest
    {
        public string FileName { get; set; }
        public Guid EntityId { get; set; }
    }
}
