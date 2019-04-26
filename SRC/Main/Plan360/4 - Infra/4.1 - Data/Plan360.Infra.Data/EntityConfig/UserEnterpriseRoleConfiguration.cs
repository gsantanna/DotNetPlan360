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
    // UserEnterpriseRole
    internal class UserEnterpriseRoleConfiguration : EntityTypeConfiguration<UserEnterpriseRole>
    {
        public UserEnterpriseRoleConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".UserEnterpriseRole");
            HasKey(x => new { x.IdUser, x.IdEnterprise, x.IdRole });

            Property(x => x.IdUser).HasColumnName("iduser").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IdEnterprise).HasColumnName("identerprise").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.IdRole).HasColumnName("idrole").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Foreign keys
            HasRequired(a => a.UserProfile).WithMany(b => b.UserEnterpriseRoles).HasForeignKey(c => c.IdUser); // FK_UserEnterpriseRole_UserProfile
            HasRequired(a => a.Enterprise).WithMany(b => b.UserEnterpriseRoles).HasForeignKey(c => c.IdEnterprise); // FK_UserEnterpriseRole_Enterprise
            HasRequired(a => a.Role).WithMany(b => b.UserEnterpriseRoles).HasForeignKey(c => c.IdRole); // FK_UserEnterpriseRole_Role
        }
    }

}
