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
    // Enterprise
    internal class EnterpriseConfiguration : EntityTypeConfiguration<Enterprise>
    {
        public EnterpriseConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Enterprise");
            HasKey(x => x.IdEnterprise);

            Property(x => x.IdEnterprise).HasColumnName("identerprise").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired().IsUnicode(false).HasMaxLength(100);

            Property(x => x.Active).IsRequired().HasColumnName("active").HasColumnAnnotation("DefaultValue", true);

        }
    }

}
