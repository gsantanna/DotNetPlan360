using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Plan360.UI.Resources;
using Plan360.Utilities;

namespace Plan360.UI.ViewModels
{


    public class EnterpriseViewModel
    {

        [Key]
        public int IdEnterprise { get; set; }

        [Required(ErrorMessageResourceName = "ERROR_Required", ErrorMessageResourceType = typeof(Plan360Strings))]
        [StringLength( 100, ErrorMessageResourceName = "ERROR_Size", ErrorMessageResourceType = typeof(Plan360Strings))]
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

    }

    

}
