

namespace Plan360.UI.JsModels
{
    public class jsPlanParameter
    {

        public int IdPlanParameter { get; set; } //PK
        public int IdPlan { get; set; } //FK_TO_PLAN
        public int IdPlanProduct { get; set; } //FK_TO_PLAN_PRODUCT 
        public int IdPlanEntity { get; set; } //FK_TO_PLAN_ENTITY
        public int Count { get; set; }
        public int Percent { get; set; }
        public int Total { get; set; }
        public int TotalA { get; set; }
        
    }
}

