﻿using FinalProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Configurations;

public class FlavourConfugration : IEntityTypeConfiguration<Flavour>
{
    public void Configure(EntityTypeBuilder<Flavour> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(10);
        builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(4));
    }
}
