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
    // InvoiceProductSource
    internal class InvoiceProductSourceConfiguration : EntityTypeConfiguration<InvoiceProductSource>
    {
        public InvoiceProductSourceConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".InvoiceProductSource");
            HasKey(x => new { x.IdInvoice, x.IdProduct, x.IdPlanparameter });

            Property(x => x.IdInvoice).HasColumnName("idinvoice").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IdProduct).HasColumnName("idproduct").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IdPlanparameter).HasColumnName("idplanparameter").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.InvoiceProduct).WithMany(b => b.InvoiceProductSources).HasForeignKey(c => new { c.IdInvoice, c.IdProduct }); // FK_InvoiceProductSource_InvoiceProduct
        }
    }

}
