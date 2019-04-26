// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Plan360.Domain.Entities;

namespace Plan360.Infra.Data.EntityConfig
{
    // UserProfile
    internal class StockConfiguration : EntityTypeConfiguration<Stock>
    {
        public StockConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Stock").HasKey(f=> new {  f.idCalendar, f.idProduct } );
            Property(x => x.BaseQuantity).HasColumnName("basequantity").IsOptional().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
        }
    }

}
