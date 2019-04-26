using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Plan360.UI.Resources;

namespace Plan360.UI.ViewModels.Product
{
    public  class ProductCategoryViewModel
    {
       [Key]
       public int IdCategory { get; set; } // id_category (Primary key)

       [Required(ErrorMessageResourceName = "ERROR_Required", ErrorMessageResourceType = typeof(Plan360Strings))]
       [Display(Name = "Name", ResourceType = typeof(Plan360Strings))]
       [DefaultValue(true)]
       public string Name { get; set; } // name


       [StringLength(100, ErrorMessageResourceName = "ERROR_Size", ErrorMessageResourceType = typeof(Plan360Strings))]
       [DataType(DataType.MultilineText)]
       [Display(Name = "Description", ResourceType = typeof(Plan360Strings))]
       public string Description { get; set; } // description

       [StringLength(100, ErrorMessageResourceName = "ERROR_Size", ErrorMessageResourceType = typeof(Plan360Strings))]
       [Display(Name = "InvoiceConfig", ResourceType = typeof(Plan360Strings))]
       public string InvoiceConfig { get; set; } // invoice_config

    }
}
