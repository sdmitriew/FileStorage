using Modulbank.FileStorage.BL.Contracts;
using Modulbank.FileStorage.StorageServices.Contracts.Entities;

namespace Modulbank.FileStorage.StorageServices.Contracts.Mappers
{
    public class ConnectedEntityMapper
    {
        public ConnectedEntity Map(ConnectedEntityModel model)
        {
            return new ConnectedEntity()
            {
                ConnectedEntityId = model.ConnectedEntityId,
                FileId = model.FileId,
                SolutionName = model.SolutionName
            };
        }

        public ConnectedEntityModel Map(ConnectedEntity entity)
        {
            return new ConnectedEntityModel()
            {
                ConnectedEntityId = entity.ConnectedEntityId,
                FileId = entity.FileId,
                SolutionName = entity.SolutionName
            };
        }
    }
}
