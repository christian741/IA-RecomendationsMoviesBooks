using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", "users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Nickname)
                .HasColumnName("nickname")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.RoleId)
                .HasColumnName("role_id")
                .IsRequired();

            builder.Property(x => x.Avatar)
                .HasColumnName("avatar");

            builder.Property(x => x.Image)
                .HasColumnName("image");

            builder.Property(x => x.Enabled)
                .HasColumnName("enabled");

            builder.Property(x => x.RegistrationDate)
                .HasColumnName("registration_date");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

            // Relationship
            builder.HasOne(x => x.Role)
                .WithMany(z => z.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_roles");
        }
    }
}
