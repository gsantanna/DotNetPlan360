

using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
   
    public class PlanEntity
    {
        
        public int IdPlanEntity { get; set; } //PK Key

        public int IdPlan { get; set; } //ID plan  
        public int IdEntitymetadata { get; set; } // IdEntityMetadata  
        public string Value { get; set; } //Vlue 

        public virtual ICollection<PlanEntityCount> PlanEntityCounts { get; set; }
 

        //reverse navigation 
        public virtual ICollection<PlanParameter> PlanParameters { get; set; }
       
        // Foreign keys
        public virtual EntityMetadata EntityMetadata { get; set; } // FK_PlanEntity_EntityMetadata
        public virtual Plan Plan { get; set; } // FK_PlanEntity_Plan

    }


}
