using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Core.Models;

namespace FinalProject.ViewModels;

public class HomeVM
{
    public IEnumerable<ProductGetDTO> Products { get; set; }

    public  IEnumerable<CategoryGetDTO> Categories { get; set; }
    public  IEnumerable<Flavour> Flavours { get; set; }
    public IEnumerable<Size> Sizes { get; set; }

    public ProductGetDTO Product { get; set; }

    

  


}
