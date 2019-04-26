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
    // Brand
    internal class BrandConfiguration : EntityTypeConfiguration<Brand>
    {
        public BrandConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Brand");
            HasKey(x => x.IdBrand);

            Property(x => x.IdBrand).HasColumnName("idbrand").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IdEnterprise).HasColumnName("identerprise").IsRequired();
            Property(x => x.Name).HasColumnName("name").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Photo).HasColumnName("photo").IsOptional().HasMaxLength(2147483647);
            Property(x => x.Active).IsRequired().HasColumnName("active").HasColumnAnnotation("DefaultValue", true);
            // Foreign keys
            HasRequired(a => a.Enterprise).WithMany(b => b.Brands).HasForeignKey(c => c.IdEnterprise); // FK_Brand_Enterprise
        }
    }

}
