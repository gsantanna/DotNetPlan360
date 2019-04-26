 

namespace Plan360.Domain.Entities
{
    public class PlanEntityCount
    {
        public int IdPlanEntity { get; set; }
        public int IdAgent { get; set; }
        public int Count { get; set; }

        //foreign keys 
        public virtual Agent Agent { get; set; }
        public virtual PlanEntity PlanEntity { get; set; }



    }

}
