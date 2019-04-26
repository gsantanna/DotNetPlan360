// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Plan360.Domain.Entities;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace Plan360.Infra.Data.EntityConfig
{
    // Role
    internal class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Role");
            HasKey(x => x.IdRole);

            Property(x => x.IdRole).HasColumnName("idrole").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("name").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Description).HasColumnName("description").IsOptional();

            Property(x => x.IsAdmin).HasColumnName("isadmin");
            Property(x => x.IsGlobalAdmin).HasColumnName("isglobaladmin");

            Property(x => x.CanParametrize).HasColumnName("canparametrize");









        }
    }

}
