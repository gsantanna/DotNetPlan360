// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
using Plan360.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace Plan360.Infra.Data.EntityConfig
{
    // Invoice
    internal class InvoiceConfiguration : EntityTypeConfiguration<Invoice>
    {
        public InvoiceConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Invoice");
            HasKey(x => x.IdInvoice);

            Property(x => x.IdInvoice).HasColumnName("idinvoice").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IdAgent).HasColumnName("idagent").IsRequired();
            Property(x => x.IdCalendar).HasColumnName("idcalendar").IsRequired();

            // Foreign keys
            HasRequired(a => a.Agent).WithMany(b => b.Invoices).HasForeignKey(c => c.IdAgent); // FK_Invoice_Agent
            HasRequired(a => a.Calendar).WithMany(b => b.Invoices).HasForeignKey(c => c.IdCalendar); // FK_Invoice_Calendar
        }
    }

}
