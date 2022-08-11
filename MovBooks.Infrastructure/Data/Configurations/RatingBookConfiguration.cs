using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Data.Configurations
{
    public class RatingBookConfiguration : IEntityTypeConfiguration<RatingBook>
    {
        public void Configure(EntityTypeBuilder<RatingBook> builder)
        {
            builder.ToTable("ratings", "books");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(x => x.BookId)
                .HasColumnName("book_id")
                .IsRequired();

            builder.Property(x => x.Rating)
                .HasColumnName("rating")
                .IsRequired();

            builder.Property(x => x.RatingDate)
                .HasColumnName("rating_date");

            builder.Property(x => x.Comment)
                .HasColumnName("comment");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

            // Relationship
            builder.HasOne(x => x.User)
                .WithMany(z => z.RatingsBooks)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("fk_rating_user_id")
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Book)
                .WithMany(z => z.RatingsBooks)
                .HasForeignKey(x => x.BookId)
                .HasConstraintName("fk_rating_book_id")
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
