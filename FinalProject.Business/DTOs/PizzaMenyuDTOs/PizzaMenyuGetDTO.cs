using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.PizzaMenyuDTOs;

public class PizzaMenyuGetDTO
{
    public int Id { get; set; } 
    public string Title { get; set; }

    public string? Description { get; set; }

    public int Price { get; set; }

    public string? ImageUrl { get; set; }

    public IFormFile ImageFile { get; set; } 

}
