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
    // Calendar
    internal class CalendarConfiguration : EntityTypeConfiguration<Calendar>
    {
        public CalendarConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Calendar");
            HasKey(x => x.IdCalendar);

            Property(x => x.IdCalendar).HasColumnName("idcalendar").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IdEnterprise).HasColumnName("identerprise").IsRequired();
            Property(x => x.Name).HasColumnName("name").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Description).HasColumnName("description").IsOptional();
            Property(x => x.Sartdate).HasColumnName("sartdate").IsRequired();
            Property(x => x.Enddate).HasColumnName("enddate").IsRequired();
            Property(x => x.Created).HasColumnName("created").IsOptional();
            Property(x => x.Modified).HasColumnName("modified").IsOptional();


            // Foreign keys
            HasRequired(a => a.Enterprise).WithMany(b => b.Calendars).HasForeignKey(c => c.IdEnterprise); // FK_Calendar_Enterprise
        }
    }

}
