using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;


namespace MovBooks.Infrastructure.Data.Configurations
{
    public class ViewsMoviesConfiguration : IEntityTypeConfiguration<ViewsMovies>
    {
         public void Configure(EntityTypeBuilder<ViewsMovies> builder)
         {
            
            
         }
    }
}

