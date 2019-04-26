
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    // Entity
    public class Entity
    {
        public int IdEntity { get; set; } // id_entity (Primary key)
        public string Name { get; set; } // name
        public string Description { get; set; } // description
        public DateTime? Created { get; set; } // created
        public DateTime? Modified { get; set; } // modified
        public bool Active { get; set; } // active
        public int IdEnterprise { get; set; } // id_enterprise

        // Reverse navigation
        public virtual ICollection<EntityMetadata> EntityMetadatas { get; set; } // EntityMetadata.FK_EntityMetadata_Entity
        public virtual ICollection<EntityRecord> EntityRecords { get; set; } // EntityRecord.FK_EntityRecord_Entity

        // Foreign keys
        public virtual Enterprise Enterprise { get; set; } // FK_Entity_Enterprise

        public Entity()
        {
            Created = DateTime.Now;
            Modified = DateTime.Now;
            EntityMetadatas = new List<EntityMetadata>();
            EntityRecords = new List<EntityRecord>();
        }
    }

}
