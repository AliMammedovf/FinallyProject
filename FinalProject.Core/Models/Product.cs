﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Models;

public class Product: BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public string AdditionalInfo { get; set; } = null!;

    public bool IsAvialable { get; set; }
    public double Price { get; set; }  

    public int CategoryId { get; set; }

    public int FlavourId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public Flavour Flavour { get; set; }
    public Category Category { get; set; }

    public List<ProductSize> ProductSizes { get; set; }

    
    

}
