using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Data.Configurations
{
    public class PasswordRecoveryConfiguration : IEntityTypeConfiguration<PasswordRecovery>
    {
        public void Configure(EntityTypeBuilder<PasswordRecovery> builder)
        {
            builder.ToTable("password_recoveries", "users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Token)
                .HasColumnName("token")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}
