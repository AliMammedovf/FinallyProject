using FinalProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FinalProject.Data.Configurations;

public class SizeConfugration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.Property(x=>x.Name).IsRequired().HasMaxLength(10);
        builder.Property(x=>x.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(4));
    }
}
