using ARAINV.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ARAINV.Core.Data.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tbUsers", "aranda");

            builder.HasIndex(e => e.EmailUser, "UIDX_USER_EMAILUSER")
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

            builder.Property(e => e.NameUser)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name_user");

            builder.Property(e => e.EmailUser)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email_user");

            builder.Property(e => e.PasswordUser)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("password_user");

            builder.Property(e => e.deleted)
                    .HasColumnType("bit")
                    .HasColumnName("deleted");
        }
    }
}
