using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Infrastructure.Data.Configurations
{
    public class GenderBooksConfiguration : IEntityTypeConfiguration<GenderBooks>
    {
        public void Configure(EntityTypeBuilder<GenderBooks> builder)
        {
            builder.ToTable("gender_books","books");
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.IdGender)
                .HasColumnName("gender_id")
                .IsRequired();

            builder.Property(x => x.IdBook)
               .HasColumnName("book_id")
               .IsRequired();

            builder.Property(x => x.CreatedAt)
               .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

            // Relationship
            builder.HasOne(x => x.Gender)
                .WithMany(z => z.GenderBooks)
                .HasForeignKey(x => x.IdGender)
                .HasConstraintName("fk_gender_books_gender_id")
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Book)
                .WithMany(z => z.GenderBooks)
                .HasForeignKey(x => x.IdBook)
                .HasConstraintName("fk_gender_books_book_id")
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
