

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Plan360.UI.Resources;
using Plan360.Utilities;

namespace Plan360.UI.ViewModels
{
    public class CalendarViewModel
    {
        [Key]
        public int IdCalendar { get; set; } // id_calendar (Primary key)


        [Display(Name = "ENTERPRISE", ResourceType = typeof(Plan360Strings))]
        [UIHint("IdEnterpriseSelector")]
        public int IdEnterprise { get; set; } // id_enterprise

        [StringLength(1000, ErrorMessageResourceName = "ERROR_Size", ErrorMessageResourceType = typeof(Plan360Strings))]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", ResourceType = typeof(Plan360Strings))]

        public string Description { get; set; } // 


        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceName = "ERROR_Required", ErrorMessageResourceType = typeof(Plan360Strings))]
        [Display(Name = "StartDate", ResourceType = typeof(Plan360Strings))]

        public DateTime Sartdate { get; set; } // sartdate

        [DataType(DataType.Date)]
        [Display(Name = "EndDate", ResourceType = typeof(Plan360Strings))]

        [Required(ErrorMessageResourceName = "ERROR_Required", ErrorMessageResourceType = typeof(Plan360Strings))]
        public DateTime Enddate { get; set; } // enddate


        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }



        [Required(ErrorMessageResourceName = "ERROR_Required", ErrorMessageResourceType = typeof(Plan360Strings))]
        [StringLength(100, ErrorMessageResourceName = "ERROR_Size", ErrorMessageResourceType = typeof(Plan360Strings))]
        [Display(Name = "Name", ResourceType = typeof(Plan360Strings))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "ERROR_Required", ErrorMessageResourceType = typeof(Plan360Strings))]
        [Display(Name = "Status", ResourceType = typeof(Plan360Strings))]
        [DefaultValue(true)]
        public bool Active { get; set; }

        public GBool ActiveGlyph
        {
            get
            {
                return Active.ToGbool();
            }
        }

        public DateTime? ClosedDate { get; set; }

        public bool IsClosed
        {
            get
            {
                return ClosedDate.HasValue;
            }
        }



    }
}
