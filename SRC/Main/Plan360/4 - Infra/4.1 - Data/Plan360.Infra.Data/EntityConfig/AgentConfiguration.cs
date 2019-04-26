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
    // Agent
    internal class AgentConfiguration : EntityTypeConfiguration<Agent>
    {
        public AgentConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Agent");
            HasKey(x => x.IdAgent);

            Property(x => x.IdAgent).HasColumnName("idagent").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IdSalesforce).HasColumnName("idsalesforce").IsRequired();
            Property(x => x.Code).HasColumnName("code").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Name).HasColumnName("name").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Parent).HasColumnName("parent").IsOptional();
            Property(x => x.Street).HasColumnName("street").IsOptional().IsUnicode(false).HasMaxLength(130);
            Property(x => x.Number).HasColumnName("number").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Zipcode).HasColumnName("zipcode").IsOptional();
            Property(x => x.City).HasColumnName("city").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.State).HasColumnName("state").IsOptional().IsUnicode(false).HasMaxLength(2);
            Property(x => x.Country).HasColumnName("country").IsOptional().IsUnicode(false).HasMaxLength(40);
            Property(x => x.IdAgentrole).HasColumnName("idagentrole").IsRequired();
            Property(x => x.Email).HasColumnName("email").IsOptional().IsUnicode(false).HasMaxLength(120);
            Property(x => x.Phone).HasColumnName("phone").IsOptional().IsUnicode(false).HasMaxLength(30);
            Property(x => x.IdErp).HasColumnName("iderp").IsRequired().IsUnicode(false).HasMaxLength(100);

            Property(x => x.Document).HasColumnName("document").IsOptional().IsUnicode(false).HasMaxLength(100);



            // Foreign keys
            HasRequired(a => a.SalesForce).WithMany(b => b.Agents).HasForeignKey(c => c.IdSalesforce); // FK_Agent_SalesForce
            HasOptional(a => a.Agent_Parent).WithMany(b => b.Agents).HasForeignKey(c => c.Parent); // FK_Agent_Agent
            HasRequired(a => a.AgentRole).WithMany(b => b.Agents).HasForeignKey(c => c.IdAgentrole); // FK_Agent_AgentRole
            HasMany(t => t.Plans).WithMany(t => t.Agents).Map(m => 
            {
                m.ToTable("PlanAgent", schema);
                m.MapLeftKey("idagent");
                m.MapRightKey("idplan");
            });
        }
    }

}
