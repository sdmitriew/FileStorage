using System;
using System.Collections.Generic;
using System.Text;
using Modulbank.FileStorage.BL.Contracts.File;
using Modulbank.FileStorage.BL.Contracts.File.Models;
using Modulbank.FileStorage.StorageServices.Contracts.Entities;
using Newtonsoft.Json;

namespace Modulbank.FileStorage.StorageServices.Contracts.Mappers
{
    public class FileMapper
    {
        public FileEntity Map(FileModel model)
        {
            return new FileEntity()
            {
                Bucket = model.Bucket,
                Created = model.Created,
                Id = model.Id,
                FileName = model.FileName,
                ContentType = model.ContentType
            };
        }

        public FileModel Map(FileEntity entity)
        {
            return new FileModel()
            {
                Bucket = entity.Bucket,
                Created = entity.Created,
                Id = entity.Id,
                FileName = entity.FileName,
                ContentType = entity.ContentType
            };
        }
    }
}
