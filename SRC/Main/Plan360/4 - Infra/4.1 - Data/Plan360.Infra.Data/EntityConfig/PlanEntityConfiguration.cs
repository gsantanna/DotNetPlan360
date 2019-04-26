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
    // Plan
    internal class PlanEntityConfiguration : EntityTypeConfiguration<PlanEntity>
    {

        public PlanEntityConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".PlanEntity");
            HasKey(x => x.IdPlanEntity);

            Property(x => x.IdPlanEntity)
                .HasColumnName("idplanentity")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(x => x.IdPlan).HasColumnName("idplan").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IdEntitymetadata).HasColumnName("identitymetadata").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Value).HasColumnName("value").IsRequired().IsUnicode(false).HasMaxLength(800).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.Plan).WithMany(b => b.PlanEntities).HasForeignKey(c => c.IdPlan).WillCascadeOnDelete(); // FK_PlanEntity_Plan
            HasRequired(a => a.EntityMetadata).WithMany(b => b.PlanEntities).HasForeignKey(c => c.IdEntitymetadata); // FK_PlanEntity_EntityMetadata
        }

    
    }



}
