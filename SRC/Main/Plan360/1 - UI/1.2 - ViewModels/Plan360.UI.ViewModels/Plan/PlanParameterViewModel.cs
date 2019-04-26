using System;
using System.ComponentModel.DataAnnotations;

namespace Plan360.UI.ViewModels.Plan
{
    public class PlanParameterViewModel
    {
        [Key]
        public int IdPlanParameter { get; set; }

        public int IdPlan { get; set; } //FK_TO_PLAN

        public int IdPlanProduct { get; set; } //FK_TO_PLAN_PRODUCT 

        public int IdPlanEntity { get; set; } //FK_TO_PLAN_ENTITY

        [UIHint("String")]
        [Range(0, 99999, ErrorMessage = @"*")]
        [Required(ErrorMessage = @"*")]
        public int Count { get; set; }

        [UIHint("String")]
        [Range(0, 999, ErrorMessage = @"*")]
        [Required(ErrorMessage = @"*")]
        public int Percent { get; set; }

        [UIHint("String")]
        public Int64 Total { get; set; }
        [UIHint("String")]
        public Int64 TotalA { get; set; }

        //Foreign Keys
        public PlanProductViewModel PlanProduct { get; set; } // 
        public PlanEntityViewModel PlanEntity { get; set; }
        public PlanViewModel Plan { get; set; } // FK_PlanEntity_Plan

    }
}
