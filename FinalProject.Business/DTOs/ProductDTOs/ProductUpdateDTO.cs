using FinalProject.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.ProductDTOs;

public class ProductUpdateDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string AdditionalInfo { get; set; } = null!;
    public bool IsAvialable { get; set; }
    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public int FlavourId { get; set; }
    public string? ImageUrl { get; set; }

    public List<int>? ProductImageIds { get; set; }

    public List<ProductImage>? ProductImages { get; set; }
    public List<ProductSize>? ProductSizes { get; set; }

    public List<int>? SizeIds { get; set; }

    public IFormFile? PosterImage { get; set; }

    public List<IFormFile>? ImageFiles { get; set; }
}
