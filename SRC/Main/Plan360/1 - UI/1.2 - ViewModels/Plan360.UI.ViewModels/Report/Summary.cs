
using Plan360.UI.Resources;
using System.ComponentModel.DataAnnotations;


namespace Plan360.UI.ViewModels.Report
{
    public class Summary
    {
        [Display(Name = "CALENDAR", ResourceType = typeof(Plan360Strings))]
        public string CalendarName { get; set; }


        [Display(Name = "AGENT_Code", ResourceType = typeof(Plan360Strings))]
        public string AgentCode { get; set; }

        [Display(Name = "AGENT", ResourceType = typeof(Plan360Strings))]
        public string AgentName { get; set; }


        [Display(Name = "AGENT_ErpCode", ResourceType = typeof(Plan360Strings))]
        public string AgentErpCode { get; set; }


        
            [Display(Name = "PRODUCTCATEGORY", ResourceType = typeof(Plan360Strings))]
        public string ProductType { get; set; }


        [Display(Name = "PRODUCT", ResourceType = typeof(Plan360Strings))]
        public string ProductName { get; set; }

        [Display(Name = "PRODUCT_Code", ResourceType = typeof(Plan360Strings))]
        public string ProductCode { get; set; }

        [Display(Name = "PRODUCT_PackSize", ResourceType = typeof(Plan360Strings))]
        public int PackSize { get; set; }

        [Display(Name = "TOTAL", ResourceType = typeof(Plan360Strings))]
        public int Total { get; set; }

        [Display(Name = "TOTALA", ResourceType = typeof(Plan360Strings))]
        public int TotalA { get; set; }


    }
}
