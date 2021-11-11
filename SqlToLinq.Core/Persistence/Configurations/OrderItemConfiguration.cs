using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlToLinq.Core.Models;

namespace SqlToLinq.Core.Persistence.Configurations
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems", "Sales");

            builder.HasKey(e => new { e.OrderId, e.Id })
                .HasName("PK__OrderIte__A0B1150FF1A6518D");

            builder.Property(e => e.Discount)
                .HasColumnType("decimal(4, 2)");

            builder.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Order)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__3A81B327");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__Produ__3B75D760");
        }
    }
}