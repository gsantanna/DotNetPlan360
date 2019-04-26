
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    // Brand
    public class Brand
    {
        public int IdBrand { get; set; } // id_brand (Primary key)
        public int IdEnterprise { get; set; } // id_enterprise
        public string Name { get; set; } // name
        public byte[] Photo { get; set; } // photo
        public bool Active { get; set; } //Active 

        // Reverse navigation
        public virtual ICollection<Product> Products { get; set; } // Product.FK_Product_Brand

        // Foreign keys
        public virtual Enterprise Enterprise { get; set; } // FK_Brand_Enterprise

        public Brand()
        {
            Products = new List<Product>();
        }
    }

}
