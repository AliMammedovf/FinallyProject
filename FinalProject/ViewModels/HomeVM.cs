using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Core.Models;

namespace FinalProject.ViewModels;

public class HomeVM
{
    public IEnumerable<ProductGetDTO> Products { get; set; }
    public  List<Category> Categories { get; set; }
    public  List<Flavour> Flavours { get; set; }
    public List<Size> Sizes { get; set; }


}
