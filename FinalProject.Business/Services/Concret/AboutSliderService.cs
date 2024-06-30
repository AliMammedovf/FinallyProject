using AutoMapper;
using FinalProject.Business.DTOs.AboutSliderDTOs;
using FinalProject.Business.DTOs.SliderDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Extensions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using FinalProject.Data.RepositoryConcret;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Concret;

public class AboutSliderService : IAboutSliderService
{

	private readonly IAboutSliderRepository _aboutSliderRepository;

	private readonly IMapper _mapper;

	private readonly IWebHostEnvironment _env;

	public AboutSliderService(IAboutSliderRepository aboutSliderRepository, IMapper mapper, IWebHostEnvironment env)
	{
		_aboutSliderRepository = aboutSliderRepository;
		_mapper = mapper;
		_env = env;
	}

	

	

	public async Task AddAboutSliderAsync(AboutSliderCreateDTO aboutSliderCreateDTO)
	{
		if (aboutSliderCreateDTO.ImageFile == null) throw new EntityNotFoundException("File connot be empty!");

		AboutSlider aboutSlider = _mapper.Map<AboutSlider>(aboutSliderCreateDTO);

		aboutSlider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\aboutsliders", aboutSliderCreateDTO.ImageFile);

		aboutSlider.IconUrl= Helper.SaveFile(_env.WebRootPath, @"uploads\aboutsliders", aboutSliderCreateDTO.IconImage);

		await _aboutSliderRepository.AddAsync(aboutSlider);
		await _aboutSliderRepository.CommitAsync();
	}

	public void DeleteAboutSlider(int id)
	{
		var existSlider = _aboutSliderRepository.Get(x => x.Id == id);

		if (existSlider == null)
			throw new EntityNotFoundException("AboutSlider not found!");

		Helper.DeleteFile(_env.WebRootPath, @"uploads\aboutsliders", existSlider.IconUrl);
		Helper.DeleteFile(_env.WebRootPath, @"uploads\aboutsliders", existSlider.ImageUrl);

		_aboutSliderRepository.Delete(existSlider);
		_aboutSliderRepository.Commit();
	}

	public AboutSliderGetDTO GetAboutSlider(Func<AboutSlider, bool>? func = null)
	{
		var sliders = _aboutSliderRepository.Get(func);

		AboutSliderGetDTO aboutSlidersDto = _mapper.Map<AboutSliderGetDTO>(sliders);
		return aboutSlidersDto;
	}

	public List<AboutSliderGetDTO> GetAllAboutSliders(Func<AboutSlider, bool>? func = null)
	{
		var sliders = _aboutSliderRepository.GetAll(func);

		List<AboutSliderGetDTO> aboutSlidersDto = _mapper.Map<List<AboutSliderGetDTO>>(sliders);
		return aboutSlidersDto;
	}

	public void UpdateAboutSlider(AboutSliderUpdateDTO aboutSliderUpdateDTO)
	{
		var existSlider = _aboutSliderRepository.Get(x => x.Id == aboutSliderUpdateDTO.Id);

		if (existSlider == null)
			throw new EntityNotFoundException("Slider not found!");

		if (aboutSliderUpdateDTO.ImageFile != null )
		{
			if (aboutSliderUpdateDTO.ImageFile.ContentType != "image/png" && aboutSliderUpdateDTO.ImageFile.ContentType != "image/jpeg")
				throw new ImageContentTypeException("File format is not avialable!");

			Helper.DeleteFile(_env.WebRootPath, @"uploads\aboutsliders", existSlider.ImageUrl);

			existSlider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\aboutsliders", aboutSliderUpdateDTO.ImageFile);
		}

		if(aboutSliderUpdateDTO.IconImage != null)
		{
            if (aboutSliderUpdateDTO.IconImage.ContentType != "image/png" && aboutSliderUpdateDTO.IconImage.ContentType != "image/jpeg")
                throw new ImageContentTypeException("File format is not avialable!");
            Helper.DeleteFile(_env.WebRootPath, @"uploads\aboutsliders", existSlider.IconUrl);
            existSlider.IconUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\aboutsliders", aboutSliderUpdateDTO.IconImage); 
        }
        

       

        existSlider.Title = aboutSliderUpdateDTO.Title;
		existSlider.Description = aboutSliderUpdateDTO.Description;
		existSlider.RedirectUrl = aboutSliderUpdateDTO.RedirectUrl;

		_aboutSliderRepository.Commit();
	}
}
