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
    // Product
    internal class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Product");
            HasKey(x => x.IdProduct);

            Property(x => x.IdProduct).HasColumnName("idproduct").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IdCategory).HasColumnName("idcategory").IsRequired();
            Property(x => x.Name).HasColumnName("name").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Description).HasColumnName("description").IsOptional();
            Property(x => x.Photo).HasColumnName("photo").IsOptional().HasMaxLength(2147483647);
            Property(x => x.Code).HasColumnName("code").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Ean).HasColumnName("ean").IsOptional().IsUnicode(false).HasMaxLength(30);
            Property(x => x.IdBrand).HasColumnName("idbrand").IsRequired();
            Property(x => x.Created).HasColumnName("created").IsOptional();
            Property(x => x.Modified).HasColumnName("modified").IsOptional();
            Property(x => x.Packsize).HasColumnName("packsize").IsRequired();
            Property(x => x.Active).IsRequired().HasColumnName("active").HasColumnAnnotation("DefaultValue", true);


            // Foreign keys
            HasRequired(a => a.ProductCategory).WithMany(b => b.Products).HasForeignKey(c => c.IdCategory); // FK_Product_ProductCategory
            HasRequired(a => a.Brand).WithMany(b => b.Products).HasForeignKey(c => c.IdBrand); // FK_Product_Brand
        }
    }

}
