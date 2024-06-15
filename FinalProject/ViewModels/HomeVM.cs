using FinalProject.Core.Models;

namespace FinalProject.ViewModels;

public class HomeVM
{
    List<Product> Products { get; set; }
    List<Category> Categories { get; set; }
    List<Flavour> Flavours { get; set; }
    List<Size> Sizes { get; set; }


}
