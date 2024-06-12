using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.ProductDTOs;

public class ProductGetDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string AdditionalInfo { get; set; } = null!;
    public bool IsAvialable { get; set; }
    public double Price { get; set; }

    public string ImageUrl { get; set; } = null!;

    public Flavour Flavour { get; set; }
    public Category Category { get; set; }
}
