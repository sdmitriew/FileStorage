using System;

namespace Modulbank.FileStorage.BL.Contracts.File.Models
{
    public class FileModel
    {
        public Guid Id { get; set; }
        public string Bucket { get; set; }
        public DateTime Created { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }

    public class MetaModel
    {
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}
