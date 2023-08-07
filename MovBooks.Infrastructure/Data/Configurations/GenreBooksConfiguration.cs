using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Data.Configurations
{
    public class GenreBooksConfiguration : IEntityTypeConfiguration<GenreBooks>
    {
        public void Configure(EntityTypeBuilder<GenreBooks> builder)
        {
            builder.ToTable("genre_books", "books");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.IdGenre)
                .HasColumnName("genre_id")
                .IsRequired();

            builder.Property(x => x.IdBook)
               .HasColumnName("book_id")
               .IsRequired();

            builder.Property(x => x.CreatedAt)
               .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

            // Relationship
            builder.HasOne(x => x.Genre)
                .WithMany(z => z.GenreBooks)
                .HasForeignKey(x => x.IdGenre)
                .HasConstraintName("fk_genre_books_Genre_id")
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Book)
                .WithMany(z => z.GenreBooks)
                .HasForeignKey(x => x.IdBook)
                .HasConstraintName("fk_genre_books_book_id")
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
