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
    // ProductCategory
    internal class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ProductCategory");
            HasKey(x => x.IdCategory);

            Property(x => x.IdCategory).HasColumnName("idcategory").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("name").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Description).HasColumnName("description").IsOptional();
            Property(x => x.InvoiceConfig).HasColumnName("invoice_config").IsOptional().IsUnicode(false).HasMaxLength(100);
        }
    }

}
