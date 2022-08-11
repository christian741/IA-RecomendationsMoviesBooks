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

         
            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

        }
    }
}

