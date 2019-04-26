

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Plan360.UI.ViewModels.Plan
{
    public class PlanEntityViewModel
    {   [Key]
        public int IdPlanEntity { get; set; }
        public int IdPlan { get; set; }
        public int IdEntityMetadata { get; set; }

        public ICollection<PlanEntityCountViewModel> PlanEntityCounts { get; set; }



        [Required]
        public string Value { get; set; }

        
        public int Count
        {
            get
            {
                return this.PlanEntityCounts.Sum(f => f.Count);

            }
        }


    }
}
