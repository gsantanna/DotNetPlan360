
using Plan360.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Plan360.Infra.Data.EntityConfig
{
    // EntityRecord
    internal class EntityRecordConfiguration : EntityTypeConfiguration<EntityRecord>
    {
        public EntityRecordConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".EntityRecord");
            HasKey(x => x.IdEntityrecord);

            Property(x => x.IdEntityrecord).HasColumnName("identityrecord").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IdEntity).HasColumnName("identity").IsRequired();
            Property(x => x.IdAgent).HasColumnName("idagent").IsRequired();
            Property(x => x.Created).HasColumnName("created").IsOptional();
            Property(x => x.Modified).HasColumnName("modified").IsOptional();
            Property(x => x.StartDate).HasColumnName("start_date").IsRequired();
            Property(x => x.EndDate).HasColumnName("end_date").IsOptional();
            Property(x => x.BusinessKey).HasColumnName("businesskey").IsRequired().IsUnicode(false).HasMaxLength(100);

            // Foreign keys
            HasRequired(a => a.Entity).WithMany(b => b.EntityRecords).HasForeignKey(c => c.IdEntity); // FK_EntityRecord_Entity
            HasRequired(a => a.Agent).WithMany(b => b.EntityRecords).HasForeignKey(c => c.IdAgent); // FK_EntityRecord_Agent
        }
    }

}
