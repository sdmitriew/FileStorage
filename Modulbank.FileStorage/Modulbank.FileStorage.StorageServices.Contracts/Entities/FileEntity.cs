using System;
using LinqToDB;
using LinqToDB.Mapping;
using Modulbank.FileStorage.BL.Contracts.File;
using Modulbank.FileStorage.BL.Contracts.File.Models;

namespace Modulbank.FileStorage.StorageServices.Contracts.Entities
{
    [Table(Name = "file")]
    public class FileEntity
    {
        [PrimaryKey]
        [Column(Name = "id"), NotNull]
        public Guid Id { get; set; }
        [Column(Name = "content_type")]
        public string ContentType { get; set; }
        [Column(Name = "filename")]
        public string FileName { get; set; }
        [Column(Name = "bucket"), NotNull]
        public string Bucket { get; set; }
        [Column(Name = "created"), NotNull]
        public DateTime Created { get; set; }
    }
}
