using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Data.Configurations
{
    public class ViewsBooksConfiguration : IEntityTypeConfiguration<ViewsBooks>
    {
        public void Configure(EntityTypeBuilder<ViewsBooks> builder)
        {
            builder.ToTable("views", "books");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Views)
             .HasColumnName("quantity_views")
             .IsRequired();

            builder.Property(x => x.UserId)
              .HasColumnName("user_id")
              .IsRequired();

            builder.Property(x => x.BookId)
                .HasColumnName("book_id")
                .IsRequired();

            // Relationship
            builder.HasOne(x => x.User)
                .WithMany(z => z.ViewsBooks)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("fk_users_view_books")
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Book)
                .WithMany(z => z.ViewsBooks)
                .HasForeignKey(x => x.BookId)
                .HasConstraintName("fk_book_view_books")
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}
