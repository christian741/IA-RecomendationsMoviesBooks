using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;


namespace MovBooks.Infrastructure.Data.Configurations
{
    public class ViewsMoviesConfiguration : IEntityTypeConfiguration<ViewsMovies>
    {
         public void Configure(EntityTypeBuilder<ViewsMovies> builder)
         {
            builder.ToTable("views", "movies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Views)
             .HasColumnName("quantity_views")
             .IsRequired();

            builder.Property(x => x.UserId)
               .HasColumnName("user_id")
               .IsRequired();

            builder.Property(x => x.MovieId)
                .HasColumnName("movie_id")
                .IsRequired();

            // Relationship
            builder.HasOne(x => x.User)
                .WithMany(z => z.ViewsMovies)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("fk_users_view_movies")
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Movie)
                .WithMany(z => z.ViewMovies)
                .HasForeignKey(x => x.MovieId)
                .HasConstraintName("fk_movie_view_movies")
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

        }
    }
}

