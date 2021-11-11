using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlToLinq.Core.Models;

namespace SqlToLinq.Core.Persistence.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.ToTable("Orders", "Sales");

            builder.Property(e => e.OrderDate)
                .HasColumnType("date");

            builder.Property(e => e.RequiredDate)
                .HasColumnType("date");

            builder.Property(e => e.ShippedDate)
                .HasColumnType("date");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Orders__Customer__34C8D9D1");

            builder.HasOne(d => d.Staff)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__StaffId__36B12243");

            builder.HasOne(d => d.Store)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__Orders__StoreId__35BCFE0A");

        }
    }
}