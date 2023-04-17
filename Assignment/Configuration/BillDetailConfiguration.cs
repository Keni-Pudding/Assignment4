using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configuration
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.ToTable("BillDetail");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Quantily).HasColumnType("int");
            builder.Property(p=>p.Price).HasColumnType("int");
            builder.HasOne(x => x.Bill).WithMany(y => y.BillDetails).HasForeignKey(c => c.IDHD);
            builder.HasOne(x => x.Products).WithMany(y => y.BillDetails).HasForeignKey(c => c.IDSP);

        }
    }
}
