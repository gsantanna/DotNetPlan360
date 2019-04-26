
using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
   public class PlanProduct
    {
       public int IdPlanProduct { get; set; }

       public int IdPlan { get; set; }
       public int IdProduct { get; set; }
       public int Packsize { get; set; }

       //reverse navigation
       public virtual ICollection<PlanParameter> PlanParameters { get; set; } 

       //foreign keys 
       public virtual Plan Plan { get; set; }
       public virtual Product Product { get; set; }



    }
}
