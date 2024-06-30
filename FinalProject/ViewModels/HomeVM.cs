using FinalProject.Business.DTOs.AboutSliderDTOs;
using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.DTOs.EmployeeDTOs;
using FinalProject.Business.DTOs.PizzaMenyuDTOs;
using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Business.DTOs.SetMenyuHeaderDTOs;
using FinalProject.Business.DTOs.SliderDTOs;
using FinalProject.Core.Models;

namespace FinalProject.ViewModels;

public class HomeVM
{
    public IEnumerable<ProductGetDTO> Products { get; set; }

    public  IEnumerable<CategoryGetDTO> Categories { get; set; }
    public  IEnumerable<Flavour> Flavours { get; set; }
    public IEnumerable<Size> Sizes { get; set; }

    public ProductGetDTO Product { get; set; }

    public List<CheckOutVM> Checkouts { get; set; }

    public List<SliderGetDTO> Sliders { get; set; }


    public AboutSliderGetDTO AboutSlider { get; set; }

    public List<PizzaMenyuGetDTO> PizzasMenyu { get; set; }

    public List<EmployeeGetDTO> Employees { get; set; }

    public List<SetMenyuHeaderGetDTO> SetMenyuHeader { get; set; }

    public List<KomboMenyu> KomboMenyu { get; set; }
    

  


}
