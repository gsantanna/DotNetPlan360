

using System;
using Plan360.UI.ViewModels.Agent;

namespace Plan360.UI.ViewModels.Entity
{
    // EntityRecord
    public class EntityRecordViewModel
    {
        public int IdEntityrecord { get; set; } // id_entityrecord (Primary key)
        public int IdEntity { get; set; } // id_entity
        public int IdAgent { get; set; } // id_agent
        public DateTime? Created { get; set; } // created
        public DateTime? Modified { get; set; } // modified
        public DateTime StartDate { get; set; } // start_date
        public DateTime? EndDate { get; set; } // end_date
        public string BusinessKey { get; set; }// Business Key of record, used to identity the Entity record in orign systems and versioning systems/ETL and etc.



        public virtual AgentViewModel Agent { get; set; }
        public virtual EntityViewModel Entity { get; set; }

       
    }

}
