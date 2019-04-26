
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    // Invoice
    public class Invoice
    {
        public int IdInvoice { get; set; } // id_invoice (Primary key)
        public int IdAgent { get; set; } // id_agent
        public int IdCalendar { get; set; } // id_calendar

        // Reverse navigation
        public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; } // Many to many mapping

        // Foreign keys
        public virtual Agent Agent { get; set; } // FK_Invoice_Agent
        public virtual Calendar Calendar { get; set; } // FK_Invoice_Calendar

        public Invoice()
        {
            InvoiceProducts = new List<InvoiceProduct>();
        }
    }

}
