using System;
using System.Collections.Generic;

namespace Plan360.Domain.Entities
{


    public class Plan
    {
        public int IdPlan { get; set; } // idplan (Primary key)
        public int IdEnterprise { get; set; } // identerprise
        public int IdCalendar { get; set; } // idcalendar
        public string Name { get; set; } // name
        public int IdOwner { get; set; } // idowner
        public DateTime Created { get; set; } // created
        public DateTime? Modified { get; set; } // modified
        public int IdCreated { get; set; } // idcreated
        public int? IdModified { get; set; } // idmodified
        public int? IdTemplate { get; set; } // idtemplate
        public bool allowduplicates { get; set; } 

        // Reverse navigation
        public virtual ICollection<Agent> Agents { get; set; } // Many to many mapping
        public virtual ICollection<PlanEntity> PlanEntities { get; set; } // Many to many mapping
        public virtual ICollection<PlanProduct> PlanProducts { get; set; } // Many to many mapping
        
        public virtual ICollection<PlanParameter> PlanParameters { get; set; }//




        // Foreign keys
        public virtual Calendar Calendar { get; set; } // FK_Plan_Calendar
        public virtual Enterprise Enterprise { get; set; } // FK_Plan_Enterprise
        public virtual UserProfile CreatedBy { get; set; } // FK_Plan_UserProfileCreated
        public virtual UserProfile ModifiedBy { get; set; } // FK_Plan_UserProfileModified
        public virtual UserProfile Owner { get; set; } // FK_Plan_UserProfileOwner

        public Plan()
        {
            Created = DateTime.Now;

        }

    }




}
