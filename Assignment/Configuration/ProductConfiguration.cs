using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Name).HasColumnType("Nvarchar(1000)");
            builder.Property(p => p.Image).HasColumnType("Nvarchar(1000)");
            builder.Property(p => p.Price).HasColumnType("int");          
            builder.Property(p => p.Status).HasColumnType("int"); builder.Property(p => p.Description).HasColumnType("nvarchar(1000)");
            builder.HasOne(p => p.Category).WithMany(p => p.Product).HasForeignKey(p => p.CatagoryId);
            builder.HasOne(p => p.Supplier).WithMany(p => p.Product).HasForeignKey(p => p.SupplierId);
            builder.HasOne(p => p.Color).WithMany(p => p.Product).HasForeignKey(p => p.ColorId);
            builder.HasOne(p => p.Size).WithMany(p => p.Product).HasForeignKey(p => p.SizeId);
          

        }
    }
}
