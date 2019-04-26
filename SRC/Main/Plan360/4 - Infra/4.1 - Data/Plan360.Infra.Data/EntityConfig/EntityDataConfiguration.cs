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
    // EntityData
    internal class EntityDataConfiguration : EntityTypeConfiguration<EntityData>
    {
        public EntityDataConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".EntityData");
            HasKey(x => x.IdData);

            Property(x => x.IdData).HasColumnName("iddata").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IdEntitymetadata).HasColumnName("identitymetadata").IsRequired();
            Property(x => x.Value).HasColumnName("value").IsRequired().IsUnicode(false).HasMaxLength(8000);
            Property(x => x.IdEntityrecord).HasColumnName("identityrecord").IsOptional();

            // Foreign keys
            HasRequired(a => a.EntityMetadata).WithMany(b => b.EntityDatas).HasForeignKey(c => c.IdEntitymetadata); // FK_EntityData_EntityMetadata1
            HasOptional(a => a.EntityRecord).WithMany(b => b.EntityDatas).HasForeignKey(c => c.IdEntityrecord); // FK_EntityData_EntityRecord
        }
    }

}
