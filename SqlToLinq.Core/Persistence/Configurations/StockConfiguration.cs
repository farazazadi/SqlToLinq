using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlToLinq.Core.Models;

namespace SqlToLinq.Core.Persistence.Configurations
{
    internal class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks", "Production");

            builder.HasKey(e => new { e.StoreId, e.ProductId })
                .HasName("PK__Stocks__F0C23D6DA96764B2");


            builder.HasOne(d => d.Product)
                .WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Stocks__ProductI__3F466844");

            builder.HasOne(d => d.Store)
                .WithMany(p => p.Stocks)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__Stocks__StoreId__3E52440B");
        }
    }
}