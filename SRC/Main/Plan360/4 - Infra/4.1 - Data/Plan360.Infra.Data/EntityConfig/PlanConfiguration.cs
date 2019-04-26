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

    internal class PlanConfiguration : EntityTypeConfiguration<Plan>
    {
        public PlanConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Plan");
            HasKey(x => x.IdPlan);

            Property(x => x.IdPlan).HasColumnName("idplan").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IdEnterprise).HasColumnName("identerprise").IsRequired();
            Property(x => x.IdCalendar).HasColumnName("idcalendar").IsRequired();
            Property(x => x.Name).HasColumnName("name").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.IdOwner).HasColumnName("idowner").IsRequired();
            Property(x => x.Created).HasColumnName("created").IsRequired();
            Property(x => x.Modified).HasColumnName("modified").IsOptional();
            Property(x => x.IdCreated).HasColumnName("idcreated").IsRequired();
            Property(x => x.IdModified).HasColumnName("idmodified").IsOptional();
            Property(x => x.IdTemplate).HasColumnName("idtemplate").IsOptional();
            

            // Foreign keys
            HasRequired(a => a.Enterprise).WithMany(b => b.Plans).HasForeignKey(c => c.IdEnterprise); // FK_Plan_Enterprise
            HasRequired(a => a.Calendar).WithMany(b => b.Plans).HasForeignKey(c => c.IdCalendar); // FK_Plan_Calendar
            HasRequired(a => a.Owner).WithMany(b => b.Plans_IdOwner).HasForeignKey(c => c.IdOwner); // FK_Plan_UserProfileOwner
            HasRequired(a => a.CreatedBy).WithMany(b => b.Plans_IdCreated).HasForeignKey(c => c.IdCreated); // FK_Plan_UserProfileCreated
            HasOptional(a => a.ModifiedBy).WithMany(b => b.Plans_IdModified).HasForeignKey(c => c.IdModified); // FK_Plan_UserProfileModified
            
        }
    }


}
