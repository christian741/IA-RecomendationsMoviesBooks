using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Data.Configurations
{
    internal class GenreMoviesConfiguration : IEntityTypeConfiguration<GenreMovies>
    {
        public void Configure(EntityTypeBuilder<GenreMovies> builder)
        {
            builder.ToTable("genre_movies", "movies");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.IdGenre)
                .HasColumnName("genre_id");

            builder.Property(x => x.IdMovie)
                .HasColumnName("movie_id");

            builder.Property(x => x.CreatedAt)
               .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

            // Relationship
            builder.HasOne(x => x.Genre)
                .WithMany(z => z.GenreMovies)
                .HasForeignKey(x => x.IdGenre)
                .HasConstraintName("fk_genre_movies_Genre_id")
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Movie)
                .WithMany(z => z.GenreMovies)
                .HasForeignKey(x => x.IdMovie)
                .HasConstraintName("fk_genre_movies_movie_id")
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
