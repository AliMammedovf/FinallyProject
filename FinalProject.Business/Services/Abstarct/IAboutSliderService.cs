using FinalProject.Business.DTOs.AboutSliderDTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public interface IAboutSliderService
{
	Task AddAboutSliderAsync(AboutSliderCreateDTO aboutSliderCreateDTO);

	void DeleteAboutSlider(int id);

	void UpdateAboutSlider(AboutSliderUpdateDTO aboutSliderUpdateDTO);

	AboutSliderGetDTO GetAboutSlider(Func<AboutSlider, bool>? func = null);

	List<AboutSliderGetDTO> GetAllAboutSliders(Func<AboutSlider, bool>? func = null);

}
