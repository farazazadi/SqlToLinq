using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlToLinq.Core.Models;

namespace SqlToLinq.Core.Persistence.Configurations
{
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores", "Sales");

            builder.Property(e => e.City)
                .HasMaxLength(255);

            builder.Property(e => e.Email)
                .HasMaxLength(255);

            builder.Property(e => e.Phone)
                .HasMaxLength(25);

            builder.Property(e => e.State)
                .HasMaxLength(10);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Street)
                .HasMaxLength(255);

            builder.Property(e => e.ZipCode)
                .HasMaxLength(5);
        }
    }
}