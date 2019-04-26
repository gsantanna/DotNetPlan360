
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    // InvoiceProduct
    public class InvoiceProduct
    {
        public int IdInvoice { get; set; } // id_invoice (Primary key)
        public int IdProduct { get; set; } // id_product (Primary key)
        public int Count { get; set; } // count

        // Reverse navigation
        public virtual ICollection<InvoiceProductSource> InvoiceProductSources { get; set; } // Many to many mapping

        // Foreign keys
        public virtual Invoice Invoice { get; set; } // FK_InvoiceProduct_Invoice

        public InvoiceProduct()
        {
            InvoiceProductSources = new List<InvoiceProductSource>();
        }
    }

}
