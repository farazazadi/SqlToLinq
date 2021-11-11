using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlToLinq.Core.Models;

namespace SqlToLinq.Core.Persistence.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "Production");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
        }

    }
}
