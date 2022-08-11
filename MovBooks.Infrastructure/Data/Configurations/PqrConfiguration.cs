using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Data.Configurations
{
    public class PqrConfiguration : IEntityTypeConfiguration<Pqr>
    {
        public void Configure(EntityTypeBuilder<Pqr> builder)
        {
            builder.ToTable("pqrs", "users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(x => x.Answer)
                .HasColumnName("answer")
                .HasMaxLength(255);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

            // Relationship
            builder.HasOne(x => x.User)
                .WithMany(z => z.Pqrs)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasConstraintName("fk_pqrs_users");
        }
    }
}
