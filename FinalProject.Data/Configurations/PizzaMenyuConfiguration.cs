using FinalProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Configurations;

public class PizzaMenyuConfiguration : IEntityTypeConfiguration<PizzaMenyu>
{
    public void Configure(EntityTypeBuilder<PizzaMenyu> builder)
    {
        builder.Property(x => x.Title).IsRequired().HasMaxLength(30);
        builder.Property(x=>x.Description).HasMaxLength(30);
        builder.Property(x => x.Price).IsRequired();

    }
}
