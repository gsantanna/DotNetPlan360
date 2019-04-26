

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Plan360.Domain.Entities;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;



namespace Plan360.Infra.Data.EntityConfig
{
    internal  class PlanEntityCountConfiguration : EntityTypeConfiguration<PlanEntityCount>
    {

        public PlanEntityCountConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".PlanEntityCount");
            HasKey(x => new { x.IdPlanEntity , x.IdAgent});

            Property(x => x.IdAgent)
                .IsRequired()
                .HasColumnName("idagent")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            Property(x => x.Count)
                .IsRequired()
                .HasColumnName("count")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //foreign key
            HasRequired(a => a.PlanEntity).WithMany(b => b.PlanEntityCounts).HasForeignKey(c => c.IdPlanEntity).WillCascadeOnDelete(); // FK_PlanEntityCouns_PlanEntity
         










        }



    }
}
