using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3.Model;
using Modulbank.FileStorage.BL.Contracts.Storage;

namespace Modulbank.FileStorage.BL.Storage
{
    public class FileStorageHelper: IFileStorageHelper
    {
        private readonly MinioHelper _minioHelper;
        public FileStorageHelper(MinioHelper minioHelper)
        {
            _minioHelper = minioHelper;
        }

        public async Task<Stream> GetFileAsync(Guid objectName, string bucket)
        {
            var response = await _minioHelper.Instance.GetObjectAsync(bucket, objectName.ToString());
            return response.ResponseStream;
        }

        public async Task<Guid> SaveFile(Stream stream, string bucket)
        {
            var objectName = Guid.NewGuid();
            await _minioHelper.Instance.PutObjectAsync(new PutObjectRequest()
            {
                BucketName = bucket,
                InputStream = stream,
                Key = objectName.ToString()
            });
            return objectName;
        }
    }
}
