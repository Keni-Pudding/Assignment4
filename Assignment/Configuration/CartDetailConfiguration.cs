using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configuration
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.ToTable("CartDetail");
            builder.HasKey(x=>x.ID);
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.Cart).WithMany(y => y.CartDetails).HasForeignKey(x => x.UserID).HasConstraintName("FK_Cart");
            builder.HasOne(x => x.Product).WithMany(y => y.CartDetails).HasForeignKey(x => x.ProductId);
        }
    }
}
