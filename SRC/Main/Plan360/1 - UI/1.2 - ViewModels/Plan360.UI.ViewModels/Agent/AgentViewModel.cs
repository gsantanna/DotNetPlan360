
namespace Plan360.UI.ViewModels.Agent
{

   public class AgentViewModel
    {
       public int IdAgent { get; set; }
       public string Name { get; set; }
       public string Code { get; set; }
       public string Document { get; set; }

       public int IdAgentRole { get; set; }
       public int IdSalesForce { get; set; }

       public SalesForceViewModel SalesForce { get; set; }
       public AgentRoleViewModel AgentRole { get; set; }


       //Ajax binder methods
       public string RoleDescription
       {
           get { return AgentRole.Description; }
       }


    }

}
