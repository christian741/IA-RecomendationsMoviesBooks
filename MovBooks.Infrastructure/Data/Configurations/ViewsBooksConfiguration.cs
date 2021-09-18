using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Data.Configurations
{
    public class ViewsBooksConfiguration : IEntityTypeConfiguration<ViewsBooks>
    {
        public void Configure(EntityTypeBuilder<ViewsBooks> builder)
        {
           
        }
    }
}
