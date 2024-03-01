using ARAINV.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ARAINV.Core.Data.EntityConfigurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("tbCategory", "aranda");

            builder.HasIndex(e => e.NameCategory, "UIDX_CATEGORY_NAMECATEGORY")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.CreatedBy).HasColumnName("createdBy");

            builder.Property(e => e.LastModified)
                .HasColumnType("datetime")
                .HasColumnName("lastModified");

            builder.Property(e => e.LastModifiedBy).HasColumnName("lastModifiedBy");

            builder.Property(e => e.NameCategory)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_category");

            builder.HasOne(d => d.UserCreate)
                .WithMany(p => p.CategoriesCre)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT_CREATEDBY");

            builder.HasOne(d => d.UserModify)
                .WithMany(p => p.CategoriesMod)
                .HasForeignKey(d => d.LastModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT_MODIFIEDBY");
        }
    }
}
