using System;
using LinqToDB.Mapping;

namespace Modulbank.FileStorage.StorageServices.Contracts.Entities
{
    [Table(Name = "assigned_record_entity")]
    public class ConnectedEntity
    {
        [Column(Name = "entity_id"), NotNull]
        public Guid ConnectedEntityId { get; set; }
        [Column(Name = "file_id"), NotNull]
        public Guid FileId { get; set; }
        [Column(Name = "solution_name"), NotNull]
        public string SolutionName  { get; set; } //Имя решения (БГ, портал...)
    }
}
