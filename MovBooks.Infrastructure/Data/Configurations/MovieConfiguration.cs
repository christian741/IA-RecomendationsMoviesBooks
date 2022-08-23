using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("movies", "movies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(x => x.Title);

            builder.Property(x => x.Description)
                .HasColumnName("description");

            builder.Property(x => x.Aggregated)
                .HasColumnName("aggregated")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}
