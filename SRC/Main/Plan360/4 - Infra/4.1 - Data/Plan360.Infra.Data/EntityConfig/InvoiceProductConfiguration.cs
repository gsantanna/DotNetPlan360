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
    // InvoiceProduct
    internal class InvoiceProductConfiguration : EntityTypeConfiguration<InvoiceProduct>
    {
        public InvoiceProductConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".InvoiceProduct");
            HasKey(x => new { x.IdInvoice, x.IdProduct });

            Property(x => x.IdInvoice).HasColumnName("idinvoice").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IdProduct).HasColumnName("idproduct").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Count).HasColumnName("count").IsRequired();

            // Foreign keys
            HasRequired(a => a.Invoice).WithMany(b => b.InvoiceProducts).HasForeignKey(c => c.IdInvoice); // FK_InvoiceProduct_Invoice
        }
    }

}
