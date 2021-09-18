using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books", "books");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Description)
                .HasColumnName("description");

            builder.Property(x => x.Aggregated)
                .HasColumnName("aggregated")
                .IsRequired();
        }
    }
}
