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
    // AgentRole
    internal class AgentRoleConfiguration : EntityTypeConfiguration<AgentRole>
    {
        public AgentRoleConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".AgentRole");
            HasKey(x => x.IdAgentrole);

            Property(x => x.IdAgentrole).HasColumnName("idagentrole").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("name").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Description).HasColumnName("description").IsRequired();
            Property(x => x.Created).HasColumnName("created").IsOptional();
            Property(x => x.Modified).HasColumnName("modified").IsOptional();
        }
    }

}
