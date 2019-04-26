
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    // Product
    public class Product
    {
        public int IdProduct { get; set; } // id_product (Primary key)
        public int IdCategory { get; set; } // id_category
        public string Name { get; set; } // name
        public string Description { get; set; } // description
        public byte[] Photo { get; set; } // photo
        public string Code { get; set; } // code
        public string Ean { get; set; } // ean
        public int IdBrand { get; set; } // id_brand
        public DateTime? Created { get; set; } // created
        public DateTime? Modified { get; set; } // modified
        public int Packsize { get; set; } // packsize
        public bool Active { get; set; } // active
        
        // Reverse navigation
        public virtual ICollection<PlanProduct> PlanProducts { get; set; } // Many to many mapping

        // Foreign keys
        public virtual Brand Brand { get; set; } // FK_Product_Brand
        public virtual ProductCategory ProductCategory { get; set; } // FK_Product_ProductCategory
        
        public Product()
        {
            Created = DateTime.Now;
            Modified = DateTime.Now;
            Packsize = 1;
            Active = true;
            PlanProducts = new List<PlanProduct>();
        }
    }

}
