// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
using Plan360.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Plan360.Infra.Data.EntityConfig
{
    // EntityMetadata
    internal class EntityMetadataConfiguration : EntityTypeConfiguration<EntityMetadata>
    {
        public EntityMetadataConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".EntityMetadata");
            HasKey(x => x.IdEntitymetadata);

            Property(x => x.IdEntitymetadata).HasColumnName("identitymetadata").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IdEntity).HasColumnName("identity").IsRequired();
            Property(x => x.Name).HasColumnName("name").IsRequired().IsUnicode(false).HasMaxLength(30);
            Property(x => x.Description).HasColumnName("description").IsOptional();


            // Foreign keys
            HasRequired(a => a.Entity).WithMany(b => b.EntityMetadatas).HasForeignKey(c => c.IdEntity); // FK_EntityMetadata_Entity
        
        
        }
    }

}
