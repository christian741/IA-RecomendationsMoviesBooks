using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Infrastructure.Data.Configurations
{
    internal class GenderMoviesConfiguration : IEntityTypeConfiguration<GenderMovies>
    {
        public void Configure(EntityTypeBuilder<GenderMovies> builder)
        {
            builder.ToTable("gender_movies","movies");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.IdGender)
                .HasColumnName("gender_id");

            builder.Property(x => x.IdMovie)
                .HasColumnName("movie_id");

            builder.Property(x => x.CreatedAt)
               .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

            // Relationship
            builder.HasOne(x => x.Gender)
                .WithMany(z => z.GenderMovies)
                .HasForeignKey(x => x.IdGender)
                .HasConstraintName("fk_gender_movies_gender_id")
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Movie)
                .WithMany(z => z.GenderMovies)
                .HasForeignKey(x => x.IdMovie)
                .HasConstraintName("fk_gender_movies_movie_id")
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
