
using Plan360.UI.ViewModels.Agent;

namespace Plan360.UI.ViewModels.Plan
{
    public class PlanEntityCountViewModel
    {
        public int IdPlanEntity { get; set; }
        public int IdAgent { get; set; }
        public int Count { get; set; }

        //foreign keys 
        public virtual AgentViewModel Agent { get; set; }
        public virtual PlanEntityViewModel PlanEntity { get; set; }

    }
}
