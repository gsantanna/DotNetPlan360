
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Plan360.Domain.Entities;

namespace Plan360.Infra.Data.EntityConfig
{
    // UserProfile
    internal class UserProfileConfiguration : EntityTypeConfiguration<UserProfile>
    {
        /*
        public UserProfileConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".UserProfile");
            HasKey(x => x.IdUser);

            Property(x => x.IdUser).HasColumnName("iduser").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("name").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Login).HasColumnName("login").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Email).HasColumnName("email").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Phone).HasColumnName("phone").IsOptional().IsUnicode(false).HasMaxLength(40);
            Property(x => x.Created).HasColumnName("created").IsOptional();
            Property(x => x.Modified).HasColumnName("modified").IsOptional();

        }
        */



        public UserProfileConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".UserProfile");
            HasKey(x => x.IdUser);

            Property(x => x.IdUser).HasColumnName("iduser").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName("name").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Login).HasColumnName("login").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Email).HasColumnName("email").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Phone).HasColumnName("phone").IsOptional().IsUnicode(false).HasMaxLength(40);
            Property(x => x.Created).HasColumnName("created").IsOptional();
            Property(x => x.Modified).HasColumnName("modified").IsOptional();
            Property(x => x.Active).HasColumnName("Active").IsRequired();
        }




    }

}
