
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    // EntityRecord
    public class EntityRecord
    {
        public int IdEntityrecord { get; set; } // id_entityrecord (Primary key)
        public int IdEntity { get; set; } // id_entity
        public int IdAgent { get; set; } // id_agent
        public DateTime? Created { get; set; } // created
        public DateTime? Modified { get; set; } // modified
        public DateTime StartDate { get; set; } // start_date
        public DateTime? EndDate { get; set; } // end_date
        public string BusinessKey { get; set; }// Business Key of record, used to identity the Entity record in orign systems and versioning systems/ETL and etc.


        // Reverse navigation
        public virtual ICollection<EntityData> EntityDatas { get; set; } // EntityData.FK_EntityData_EntityRecord

        // Foreign keys
        public virtual Agent Agent { get; set; } // FK_EntityRecord_Agent
        public virtual Entity Entity { get; set; } // FK_EntityRecord_Entity

        public EntityRecord()
        {
            Created = DateTime.Now;
            Modified = DateTime.Now;
            EntityDatas = new List<EntityData>();
        }
    }

}
