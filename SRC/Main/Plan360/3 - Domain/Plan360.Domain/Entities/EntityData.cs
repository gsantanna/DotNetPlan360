
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

namespace Plan360.Domain.Entities
{
    // EntityData
    public class EntityData
    {
        public long IdData { get; set; } // id_data (Primary key)
        public int IdEntitymetadata { get; set; } // id_entitymetadata
        public string Value { get; set; } // value
        public int? IdEntityrecord { get; set; } // id_entityrecord

        // Foreign keys
        public virtual EntityMetadata EntityMetadata { get; set; } // FK_EntityData_EntityMetadata1
        public virtual EntityRecord EntityRecord { get; set; } // FK_EntityData_EntityRecord
    }

}
