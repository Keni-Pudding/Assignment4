using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnType("Nvarchar(1000)");
            builder.Property(p => p.Sdt).HasColumnType("Nvarchar(1000)");
            builder.Property(p => p.Description).HasColumnType("Nvarchar(1000)");
            builder.Property(p => p.Status).HasColumnType("Nvarchar(1000)");
            
        }
    }
}
