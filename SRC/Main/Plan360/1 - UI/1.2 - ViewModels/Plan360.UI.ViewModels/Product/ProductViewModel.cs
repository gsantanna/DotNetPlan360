using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Plan360.UI.Resources;
using Plan360.Utilities;

namespace Plan360.UI.ViewModels.Product
{
    public class ProductViewModel
    {

       [Key]
       public int IdProduct { get; set; }

       [Display(Name = "PRODUCTCATEGORY", ResourceType = typeof(Plan360Strings))]
       [UIHint("IdCategorySelector")]
       public int IdCategory { get; set; } // id_category

       [Required(ErrorMessageResourceName = "ERROR_Required", ErrorMessageResourceType = typeof(Plan360Strings))]
       [Display(Name = "Name", ResourceType = typeof(Plan360Strings))]
       [DefaultValue(true)]
       public string Name { get; set; } // name

       [StringLength(100, ErrorMessageResourceName = "ERROR_Size", ErrorMessageResourceType = typeof(Plan360Strings))]
       [DataType(DataType.MultilineText)]
       [Display(Name = "Description", ResourceType = typeof(Plan360Strings))]
       public string Description { get; set; } // description
       
       public byte[] Photo { get; set; } // photo

       [StringLength(100, ErrorMessageResourceName = "ERROR_Size", ErrorMessageResourceType = typeof(Plan360Strings))]
       [Display(Name = "Code", ResourceType = typeof(Plan360Strings))]
       public string Code { get; set; } // code

       [StringLength(100, ErrorMessageResourceName = "ERROR_Size", ErrorMessageResourceType = typeof(Plan360Strings))]
       [Display(Name = "Ean", ResourceType = typeof(Plan360Strings))]
       public string Ean { get; set; } // ean

       [Display(Name = "BRAND", ResourceType = typeof(Plan360Strings))]
       [UIHint("IdBrandSelector")]
       public int IdBrand { get; set; } // id_brand

       [DataType(DataType.Date)]
       [Display(Name = "Created", ResourceType = typeof(Plan360Strings))]
       public DateTime? Created { get; set; } // created

       [DataType(DataType.Date)]
       [Display(Name = "Modified", ResourceType = typeof(Plan360Strings))]
       public DateTime? Modified { get; set; } // modified
       
       public int Packsize { get; set; } // packsize

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
       
       
       public BrandViewModel Brand { get; set; }

       public string BrandName
       {
           get { return Brand.Name; }
       }



    }
}
