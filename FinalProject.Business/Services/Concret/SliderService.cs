using AutoMapper;
using FinalProject.Business.DTOs.SliderDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Extensions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Concret;

public class SliderService : ISliderService
{
	private readonly ISliderRepository _sliderRepository;

	private readonly IMapper _mapper;

	private readonly IWebHostEnvironment _env;

	public SliderService(ISliderRepository sliderRepository, IMapper mapper, IWebHostEnvironment env)
	{
		_sliderRepository = sliderRepository;
		_mapper = mapper;
		_env = env;
	}

	public async Task AddSliderAsync(SliderCreateDTO sliderCreateDTO)
	{
		if (sliderCreateDTO.ImageFile == null) throw new EntityNotFoundException("File connot be empty!");

		Slider slider= _mapper.Map<Slider>(sliderCreateDTO);

		slider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/sliders", sliderCreateDTO.ImageFile);

		await _sliderRepository.AddAsync(slider);
		await _sliderRepository.CommitAsync();
	}

	public void DeleteSlider(int id)
	{
		var existSlider = _sliderRepository.Get(x => x.Id == id);

		if (existSlider == null)
			throw new EntityNotFoundException("Slider not found!");

		Helper.DeleteFile(_env.WebRootPath, @"uploads/sliders", existSlider.ImageUrl);

		_sliderRepository.Delete(existSlider);
		_sliderRepository.Commit();
	}

	public List<SliderGetDTO> GetAllSliders(Func<Slider, bool>? func = null)
	{
		var sliders = _sliderRepository.GetAll(func);

		List<SliderGetDTO> slidersDto = _mapper.Map<List<SliderGetDTO>>(sliders);
		return slidersDto;
	}

	public SliderGetDTO GetSlider(Func<Slider, bool>? func = null)
	{
		var slider = _sliderRepository.Get(func);
		SliderGetDTO sliderGetDTO = _mapper.Map<SliderGetDTO>(slider);
		return sliderGetDTO;
	}

	public void UpdateSlider(SliderUpdateDTO sliderUpdateDTO)
	{
		var existSlider = _sliderRepository.Get(x => x.Id==sliderUpdateDTO.Id);

		if (existSlider == null)
			throw new EntityNotFoundException("Slider not found!");

		if (sliderUpdateDTO.ImageFile != null)
		{
			if (sliderUpdateDTO.ImageFile.ContentType != "image/png" && sliderUpdateDTO.ImageFile.ContentType!= "image/jpeg")
				throw new ImageContentTypeException("File format is not avialable!");

			Helper.DeleteFile(_env.WebRootPath, @"uploads\sliders", existSlider.ImageUrl);

			existSlider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\sliders", sliderUpdateDTO.ImageFile);

		}

		
		existSlider.Title = sliderUpdateDTO.Title;
		existSlider.Description = sliderUpdateDTO.Description;
		existSlider.RedirectUrl = sliderUpdateDTO.RedirectUrl;

		_sliderRepository.Commit();
	}
}
