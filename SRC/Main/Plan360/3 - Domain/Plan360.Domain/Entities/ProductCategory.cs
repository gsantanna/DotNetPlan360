
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    // ProductCategory
    public class ProductCategory
    {
        public int IdCategory { get; set; } // id_category (Primary key)
        public string Name { get; set; } // name
        public string Description { get; set; } // description
        public string InvoiceConfig { get; set; } // invoice_config

        // Reverse navigation
        public virtual ICollection<Product> Products { get; set; } // Product.FK_Product_ProductCategory

        public ProductCategory()
        {
            Products = new List<Product>();
        }
    }

}
