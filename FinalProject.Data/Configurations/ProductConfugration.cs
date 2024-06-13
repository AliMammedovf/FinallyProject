using FinalProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Configurations;

public class ProductConfugration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
        builder.Property(x=>x.Description).IsRequired().HasMaxLength(200);
        builder.Property(x=>x.AdditionalInfo).IsRequired().HasMaxLength(100);
        builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(4));
    }
}
