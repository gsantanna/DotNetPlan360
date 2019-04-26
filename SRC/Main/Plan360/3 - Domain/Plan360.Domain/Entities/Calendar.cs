
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    // Calendar
    public class Calendar
    {
        public int IdCalendar { get; set; } // id_calendar (Primary key)
        public int IdEnterprise { get; set; } // id_enterprise
        public string Name { get; set; } // name
        public string Description { get; set; } // description
        public DateTime Sartdate { get; set; } // sartdate
        public DateTime Enddate { get; set; } // enddate
        public DateTime Created { get; set; } // created
        public DateTime? Modified { get; set; } // modified
        public bool Active { get; set; } // active

        public DateTime? ClosedDate { get; set; }

       
        // Reverse navigation
        public virtual ICollection<Invoice> Invoices { get; set; } // Invoice.FK_Invoice_Calendar
        public virtual ICollection<Plan> Plans { get; set; } // Plan.FK_Plan_Calendar
        public virtual ICollection<Stock> Stocks { get; set; } // Stocks.FK_Stocks_Calendar


        // Foreign keys
        public virtual Enterprise Enterprise { get; set; } // FK_Calendar_Enterprise

        public Calendar()
        {
            Created = DateTime.Now;
            Modified = DateTime.Now;
            Active = true;
            Invoices = new List<Invoice>();
            Plans = new List<Plan>();

        }
    }

}
