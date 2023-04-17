using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(p => p.ID);
            builder.Property(p=>p.Username).HasColumnType("Nvarchar(1000)");
            builder.Property(p=>p.Password).HasColumnType("Nvarchar(1000)");
            builder.Property(p=>p.Status).HasColumnType("int");
            builder.HasOne(p => p.Role).WithMany(p => p.Users).HasForeignKey(x => x.RoleID).HasConstraintName("FK_user_role");
          
        }
    }
}
