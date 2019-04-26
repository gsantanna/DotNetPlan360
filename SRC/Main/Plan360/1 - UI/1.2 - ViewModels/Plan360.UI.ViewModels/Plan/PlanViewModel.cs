using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plan360.UI.Resources;
using Plan360.UI.ViewModels.Agent;



namespace Plan360.UI.ViewModels.Plan
{
   public class PlanViewModel
    {
       [Key]
       public int IdPlan { get; set; }

       [Required(ErrorMessageResourceName = "ERROR_Required", ErrorMessageResourceType = typeof(Plan360Strings))]
       [Display(Name = "ENTERPRISE", ResourceType = typeof(Plan360Strings))]
       public int IdEnterprise { get; set; }

        [Display(Name = "Owner", ResourceType = typeof(Plan360Strings))]
       [Required(ErrorMessageResourceName = "ERROR_Required", ErrorMessageResourceType = typeof(Plan360Strings))]
       public int IdOwner { get; set; }

       [Display(Name = "Owner", ResourceType = typeof(Plan360Strings))]
       public UserProfileViewModel Owner { get; set; }



       [Required(ErrorMessageResourceName = "ERROR_Required", ErrorMessageResourceType = typeof(Plan360Strings))]
       [Display(Name = "CALENDAR", ResourceType = typeof(Plan360Strings))]
       public int IdCalendar { get; set; }

       


       [Required(ErrorMessageResourceName = "ERROR_Required", ErrorMessageResourceType = typeof(Plan360Strings))]
       [StringLength(100, ErrorMessageResourceName = "ERROR_Size", ErrorMessageResourceType = typeof(Plan360Strings))]
       [Display(Name = "Name", ResourceType = typeof(Plan360Strings))]
       public string Name { get; set; }

       public int IdTemplate { get; set; }

       [DisplayFormat( DataFormatString = "{0:dd/MM/yyyy}")]
       public DateTime Created { get; set; }

       private DateTime _modified = new DateTime();
       [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
       public DateTime Modified {
           get
           {
               if (_modified == DateTime.MinValue)
               {
                   return Created;
               }
               else
               {
                   return _modified;
               }
               
           }
           set { _modified = value; } }


        [Display(Name = "CALENDAR", ResourceType = typeof(Plan360Strings))]
        public CalendarViewModel Calendar { get; set; }
       
       public List<PlanProductViewModel> PlanProducts { get; set; } 

       public List<AgentViewModel> Agents { get; set; }

       public List<PlanEntityViewModel> PlanEntities { get; set; }

       public List<PlanParameterViewModel> PlanParameters { get; set; } 

       public PlanViewModel()
       {
           PlanProducts = new List<PlanProductViewModel>();
           PlanEntities = new List<PlanEntityViewModel>();
           Agents = new List<AgentViewModel>();
           PlanParameters = new List<PlanParameterViewModel>();

          
       }



       


    }
}
