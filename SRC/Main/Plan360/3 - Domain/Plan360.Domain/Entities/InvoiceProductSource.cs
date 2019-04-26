
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

namespace Plan360.Domain.Entities
{
    // InvoiceProductSource
    public class InvoiceProductSource
    {
        public int IdInvoice { get; set; } // id_invoice (Primary key)
        public int IdProduct { get; set; } // id_product (Primary key)
        public int IdPlanparameter { get; set; } // id_planparameter (Primary key)

        // Foreign keys
        public virtual InvoiceProduct InvoiceProduct { get; set; } // FK_InvoiceProductSource_InvoiceProduct
    }

}
