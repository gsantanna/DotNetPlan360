
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    public class EntityMetadata
    {
        public int IdEntitymetadata { get; set; } // identitymetadata (Primary key)
        public int IdEntity { get; set; } // identity
        public string Name { get; set; } // name
        public string Description { get; set; } // description
        public bool Active { get; set; } // Active

        // Reverse navigation
        public virtual ICollection<EntityData> EntityDatas { get; set; } // EntityData.FK_dbo.EntityData_dbo.EntityMetadata_identitymetadata
        public virtual ICollection<PlanEntity> PlanEntities { get; set; } // Many to many mapping

        // Foreign keys
        public virtual Entity Entity { get; set; } // FK_dbo.EntityMetadata_dbo.Entity_identity

        public EntityMetadata()
        {
            EntityDatas = new List<EntityData>();
            PlanEntities = new List<PlanEntity>();
        }
    }



}
