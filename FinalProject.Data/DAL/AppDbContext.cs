﻿using FinalProject.Core.Models;
using FinalProject.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.DAL;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options): base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Size> Sizes { get; set; }

    public DbSet<ProductSize> ProductSizes { get; set; }

    public DbSet<Flavour> Flavours { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ProductConfugration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(CategoryConfugration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(FlavourConfugration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(SizeConfugration).Assembly);
        base.OnModelCreating(builder);
        
    }

    
}
