using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Data.Configurations
{
    public class RatingMovieConfiguration : IEntityTypeConfiguration<RatingMovie>
    {
        public void Configure(EntityTypeBuilder<RatingMovie> builder)
        {
            builder.ToTable("ratings", "movies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(x => x.MovieId)
                .HasColumnName("movie_id")
                .IsRequired();

            builder.Property(x => x.Rating)
                .HasColumnName("rating")
                .IsRequired();

            builder.Property(x => x.RatingDate)
                .HasColumnName("rating_date");

            builder.Property(x => x.Comment)
                .HasColumnName("comment");

            // Relationship
            builder.HasOne(x => x.User)
                .WithMany(z => z.RatingsMovies)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("fk_users")
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Movie)
                .WithMany(z => z.RatingsMovies)
                .HasForeignKey(x => x.MovieId)
                .HasConstraintName("fk_movies")
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
