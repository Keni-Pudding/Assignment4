using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Assignment.Configuration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Color");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.NameColor).HasColumnType("Nvarchar(1000)");
        }
    }
}
