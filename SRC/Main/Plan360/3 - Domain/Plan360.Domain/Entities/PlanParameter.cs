
using System;

namespace Plan360.Domain.Entities
{
    public class PlanParameter
    {
        public int IdPlanParameter { get; set; } //PK


        public int IdPlan { get; set; } //FK_TO_PLAN
        public int IdPlanProduct { get; set; } //FK_TO_PLAN_PRODUCT 
        public int IdPlanEntity { get; set; } //FK_TO_PLAN_ENTITY

        public int Count { get; set; }
        public int Percent { get; set; }

        public Int64 Total { get; set; }
        public Int64 TotalA { get; set; }


        //Foreign Keys
        public virtual PlanProduct PlanProduct { get; set; } // 
        public virtual PlanEntity PlanEntity { get; set; }
        public virtual Plan Plan { get; set; } // FK_PlanEntity_Plan
    

       

    }
}
