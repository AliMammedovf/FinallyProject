using FinalProject.Business.DTOs.SliderDTOs;
using FinalProject.Business.DTOs.SliderDTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public interface ISliderService
{
	Task AddSliderAsync(SliderCreateDTO sliderCreateDTO);

	void DeleteSlider(int id);

	void UpdateSlider(SliderUpdateDTO sliderUpdateDTO);

	SliderGetDTO GetSlider(Func<Slider, bool>? func = null);

	List<SliderGetDTO> GetAllSliders(Func<Slider, bool>? func = null);


}
