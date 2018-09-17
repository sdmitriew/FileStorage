using System;
using System.Collections.Generic;
using System.Text;
using Amazon;
using Amazon.S3;
using Modulbank.FileStorage.BL.Contracts;


namespace Modulbank.FileStorage.BL.Storage
{
    public class MinioHelper
    {
        public string Bucket { get; private set; }
        public AmazonS3Client Instance { get; private set; }
        public MinioHelper(IBusinessLogicConfigs appSettings)
        {
            Bucket = "test";
            var config = new AmazonS3Config
            {
                RegionEndpoint =
                    RegionEndpoint
                        .USEast1, 
                ServiceURL = $"http://{appSettings.MinioHost}",
                ForcePathStyle = true
            };
            Instance = new AmazonS3Client(appSettings.MinioAccessKey, appSettings.MinioSecretKey, config);
        }
    }
}
