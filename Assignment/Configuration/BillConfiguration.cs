using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configuration
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill");
            builder.HasKey(p => p.ID);
            builder.Property(p=>p.CreateDate).HasColumnType("datetime");
            builder.Property(p => p.Status).HasColumnType("int");
            builder.HasOne(p => p.User).WithMany(p => p.Bills).HasForeignKey(p => p.UserId);
           
        }
    }
}
