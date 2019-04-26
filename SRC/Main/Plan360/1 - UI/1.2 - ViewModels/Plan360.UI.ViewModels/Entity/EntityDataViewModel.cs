
namespace Plan360.UI.ViewModels.Entity
{
    // EntityData
    public class EntityDataViewModel
    {
        public long IdData { get; set; } // id_data (Primary key)
        public int IdEntitymetadata { get; set; } // id_entitymetadata
        public string Value { get; set; } // value
        public int? IdEntityrecord { get; set; } // id_entityrecord

        // Foreign keys
        public virtual EntityMetadataViewModel EntityMetadata { get; set; } // FK_EntityData_EntityMetadata1
        public virtual EntityRecordViewModel EntityRecord { get; set; } // FK_EntityData_EntityRecord
    }

}
