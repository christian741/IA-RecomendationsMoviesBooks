using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Data.Configurations
{
    public class ParameterConfiguration : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.ToTable("parameters", "config");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Key)
                .HasColumnName("key")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Value)
                .HasColumnName("value")
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
