using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlToLinq.Core.Models;

namespace SqlToLinq.Core.Persistence.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.ToTable("Customers", "Sales");

            builder.Property(e => e.City)
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Phone)
                .HasMaxLength(25);

            builder.Property(e => e.State)
                .HasMaxLength(25);

            builder.Property(e => e.Street)
                .HasMaxLength(255);

            builder.Property(e => e.ZipCode)
                .HasMaxLength(5);

        }
    }
}