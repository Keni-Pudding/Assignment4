using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.RoleName).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Description).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Status).HasColumnType("nvarchar(1000)");
        }
    }
}
