using FinalProject.Business.DTOs.AboutInfoDTOs;
using FinalProject.Business.DTOs.AboutSliderDTOs;
using FinalProject.Business.DTOs.EmployeeDTOs;
using FinalProject.Business.DTOs.PizzaMenyuDTOs;

namespace FinalProject.ViewModels;

public class AboutVM
{
	public List<EmployeeGetDTO> Employees { get; set; }

	public AboutSliderGetDTO AboutSlider { get; set; }

	public List<PizzaMenyuGetDTO> PizzasMenyu { get; set; }

	public List<AboutInfoGetDTO> AboutInfo { get; set; }
}
