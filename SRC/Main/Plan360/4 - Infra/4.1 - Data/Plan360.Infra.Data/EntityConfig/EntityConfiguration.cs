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
    // Entity
    internal class EntityConfiguration : EntityTypeConfiguration<Entity>
    {
        public EntityConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Entity");
            HasKey(x => x.IdEntity);

            Property(x => x.IdEntity).HasColumnName("identity").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("name").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Description).HasColumnName("description").IsOptional();
            Property(x => x.Created).HasColumnName("created").IsOptional();
            Property(x => x.Modified).HasColumnName("modified").IsOptional();
            Property(x => x.Active).HasColumnName("active").IsRequired();
            Property(x => x.IdEnterprise).HasColumnName("identerprise").IsRequired();

            // Foreign keys
            HasRequired(a => a.Enterprise).WithMany(b => b.Entities).HasForeignKey(c => c.IdEnterprise); // FK_Entity_Enterprise
        }
    }

}
