using ARAINV.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ARAINV.Core.Data.EntityConfigurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("tbProduct", "aranda");

            builder.HasIndex(e => e.NameProduct, "UIDX_PRODUCT_NAMEPRODUCT")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CategoryId).HasColumnName("category_id");

            builder.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.CreatedBy).HasColumnName("createdBy");

            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");

            builder.Property(e => e.LastModified)
                .HasColumnType("datetime")
                .HasColumnName("lastModified");

            builder.Property(e => e.LastModifiedBy).HasColumnName("lastModifiedBy");

            builder.Property(e => e.NameProduct)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name_product");

            builder.Property(e => e.Photo).HasColumnName("photo");

            builder.Property(e => e.deleted)
                .HasColumnType("bit")
                .HasColumnName("deleted");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.TbProducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT_CATEGORYID");

            builder.HasOne(d => d.UserCreate)
                .WithMany(p => p.ProductsCre)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT_CREATEDBY");

            builder.HasOne(d => d.UserModify)
                .WithMany(p => p.ProductsMod)
                .HasForeignKey(d => d.LastModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT_MODIFIEDBY");
        }
    }
}
