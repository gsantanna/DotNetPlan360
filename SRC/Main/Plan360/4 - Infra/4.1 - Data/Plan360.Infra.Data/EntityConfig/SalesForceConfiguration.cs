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
    // SalesForce
    internal class SalesForceConfiguration : EntityTypeConfiguration<SalesForce>
    {
        public SalesForceConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".SalesForce");
            HasKey(x => x.IdSalesforce);

            Property(x => x.IdSalesforce).HasColumnName("idsalesforce").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IdEnterprise).HasColumnName("identerprise").IsRequired();
            Property(x => x.Name).HasColumnName("name").IsRequired().IsUnicode(false).HasMaxLength(100);

            // Foreign keys
            HasRequired(a => a.Enterprise).WithMany(b => b.SalesForces).HasForeignKey(c => c.IdEnterprise); // FK_SalesForce_Enterprise
        }
    }

}
