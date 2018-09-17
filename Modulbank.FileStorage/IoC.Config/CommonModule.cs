using Autofac;
using Modulbank.FileStorage.BL.Contracts.File.Helpers;
using Modulbank.FileStorage.BL.Contracts.Storage;
using Modulbank.FileStorage.BL.Files.Handlers;
using Modulbank.FileStorage.BL.Files.Helpers;
using Modulbank.FileStorage.BL.Storage;
using Modulbank.FileStorage.StorageServices;
using Modulbank.FileStorage.StorageServices.Contracts.Core;
using Modulbank.FileStorage.StorageServices.Contracts.File;
using Modulbank.FileStorage.StorageServices.Contracts.Mappers;

namespace IoC.Config
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MinioHelper>();
            builder.RegisterType<FileMapper>();
            builder.RegisterType<GetFileHandler>();
            builder.RegisterType<AddFileHandler>();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<FileHelper>().As<IFileHelper>();
            builder.RegisterType<ConnectedEntityService>().As<IConnectedEntityService>();
            builder.RegisterType<FileStorageDb>();
            builder.RegisterType<FileStorageHelper>().As<IFileStorageHelper>();
            builder.RegisterType<MinioHelper>();
        }
    }
}
