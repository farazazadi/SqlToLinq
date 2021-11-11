using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlToLinq.Core.Models;

namespace SqlToLinq.Core.Persistence.Configurations
{
    internal class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("Staffs", "Sales");

            builder.HasIndex(e => e.Email, "UQ__Staffs__A9D105347D395FC3")
                .IsUnique();

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Phone)
                .HasMaxLength(25);

            builder.HasOne(d => d.Manager)
                .WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__Staffs__ManagerI__31EC6D26");

            builder.HasOne(d => d.Store)
                .WithMany(p => p.Staff)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__Staffs__StoreId__30F848ED");
        }
    }
}