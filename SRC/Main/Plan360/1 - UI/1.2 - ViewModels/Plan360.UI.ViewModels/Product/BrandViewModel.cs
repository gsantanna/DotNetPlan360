using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Plan360.UI.Resources;
using Plan360.Utilities;

namespace Plan360.UI.ViewModels.Product
{
    public class BrandViewModel
    {
        [Key]
        public int IdBrand { get; set; } // id_brand (Primary key)

        [Display(Name = "ENTERPRISE", ResourceType = typeof(Plan360Strings))]
        [UIHint("IdEnterpriseSelector")]
        public int IdEnterprise { get; set; } // id_enterprise

        [Required(ErrorMessageResourceName = "ERROR_Required", ErrorMessageResourceType = typeof(Plan360Strings))]
        [Display(Name = "Name", ResourceType = typeof(Plan360Strings))]
        [DefaultValue(true)]
        public string Name { get; set; } // name

        public byte[] Photo { get; set; } // photo

        [Required(ErrorMessageResourceName = "ERROR_Required", ErrorMessageResourceType = typeof(Plan360Strings))]
        [Display(Name = "Status", ResourceType = typeof(Plan360Strings))]
        [DefaultValue(true)]
        public bool Active { get; set; } //Active 

        public GBool ActiveGlyph
        {
            get
            {
                return Active.ToGbool();
            }
        }

    }
}
