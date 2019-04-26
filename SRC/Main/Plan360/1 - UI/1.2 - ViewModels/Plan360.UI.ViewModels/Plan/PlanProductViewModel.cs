using Plan360.UI.ViewModels.Product;


namespace Plan360.UI.ViewModels.Plan
{
    public class PlanProductViewModel
    {
       public int IdPlanProduct { get; set; }
       public int IdPlan { get; set; }
       public int IdProduct { get; set; }
       public int Packsize { get; set; }
       public ProductViewModel Product { get; set; }
       
    }
}
