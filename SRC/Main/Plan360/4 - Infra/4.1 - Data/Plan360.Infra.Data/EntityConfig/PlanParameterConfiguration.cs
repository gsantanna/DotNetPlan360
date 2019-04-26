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

    internal class PlanParameterConfiguration : EntityTypeConfiguration<PlanParameter>
    {
        public PlanParameterConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".PlanParameter");
            HasKey(x => x.IdPlanParameter);

            Property(x => x.IdPlanParameter).HasColumnName("idplanparameter").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IdPlan).HasColumnName("idplan").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IdPlanEntity).HasColumnName("idplanentity").IsRequired();
            Property(x => x.IdPlanProduct).HasColumnName("idplanproduct").IsRequired();
            Property(x => x.Count).HasColumnName("count").IsOptional();
            Property(x => x.Percent).HasColumnName("percent").IsOptional();
            Property(x => x.Total).HasColumnName("total").IsOptional();
            Property(x => x.TotalA).HasColumnName("totala").IsOptional();
             
            // Foreign keys
            HasRequired(a => a.Plan).WithMany(b => b.PlanParameters).HasForeignKey(c => c.IdPlan).WillCascadeOnDelete(); // FK_PlanParameter_Plan
            HasRequired(a => a.PlanEntity).WithMany(b => b.PlanParameters).HasForeignKey(c => c.IdPlanEntity).WillCascadeOnDelete(); // FK_PlanParameter_PlanEntity 
            HasRequired(a => a.PlanProduct).WithMany(b => b.PlanParameters).HasForeignKey(c => c.IdPlanProduct).WillCascadeOnDelete(); //FK_PlanParameter_PlanProducts
             

        }
    }


}
