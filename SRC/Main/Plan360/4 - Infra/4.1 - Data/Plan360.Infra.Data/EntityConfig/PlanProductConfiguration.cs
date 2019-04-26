

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Plan360.Domain.Entities;

namespace Plan360.Infra.Data.EntityConfig
{
    public class PlanProductConfiguration : EntityTypeConfiguration<PlanProduct>
    {
           public PlanProductConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".PlanProduct");
            HasKey(x => x.IdPlanProduct);

               Property(x => x.IdPlanProduct)
                   .HasColumnName("idplanproduct")
                   .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdPlan).HasColumnName("idplan").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IdProduct).HasColumnName("idproduct").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Packsize).HasColumnName("packsize").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.Plan).WithMany(b => b.PlanProducts).HasForeignKey(c => c.IdPlan).WillCascadeOnDelete() ; 
            HasRequired(a => a.Product).WithMany(b => b.PlanProducts).HasForeignKey(c => c.IdProduct); 
        }


    }
}
