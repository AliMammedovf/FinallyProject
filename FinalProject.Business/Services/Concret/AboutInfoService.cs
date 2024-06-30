using AutoMapper;
using FinalProject.Business.DTOs.AboutInfoDTOs;
using FinalProject.Business.DTOs.AboutInfoDTOs;
using FinalProject.Business.DTOs.AboutInfoDTOs;
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

public class AboutInfoService : IAboutInfoService
{


	private readonly IAboutInfoRepository _aboutInfoRepository;

	private readonly IMapper _mapper;

	private readonly IWebHostEnvironment _env;

	public AboutInfoService(IAboutInfoRepository aboutInfoRepository, IMapper mapper, IWebHostEnvironment env)
	{
		_aboutInfoRepository = aboutInfoRepository;
		_mapper = mapper;
		_env = env;
	}
	public async Task AddAboutInfoAsync(AboutInfoCreateDTO aboutInfoCreateDTO)
	{
		if (aboutInfoCreateDTO.ImageFile == null) throw new EntityNotFoundException("File connot be empty!");

		AboutInfo aboutInfo = _mapper.Map<AboutInfo>(aboutInfoCreateDTO);

		aboutInfo.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\aboutinfos", aboutInfoCreateDTO.ImageFile);

		aboutInfo.FonUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\aboutinfos", aboutInfoCreateDTO.FonImage);

		await _aboutInfoRepository.AddAsync(aboutInfo);
		await _aboutInfoRepository.CommitAsync();
	}

	public void DeleteAboutInfo(int id)
	{
		var existInfo = _aboutInfoRepository.Get(x => x.Id == id);

		if (existInfo == null)
			throw new EntityNotFoundException("AboutInfo not found!");

		Helper.DeleteFile(_env.WebRootPath, @"uploads\aboutinfos", existInfo.FonUrl);
		Helper.DeleteFile(_env.WebRootPath, @"uploads\aboutinfos", existInfo.ImageUrl);

		_aboutInfoRepository.Delete(existInfo);
		_aboutInfoRepository.Commit();
	}

	public AboutInfoGetDTO GetAboutInfo(Func<AboutInfo, bool>? func = null)
	{
		var Infos = _aboutInfoRepository.Get(func);

		AboutInfoGetDTO aboutInfosDto = _mapper.Map<AboutInfoGetDTO>(Infos);
		return aboutInfosDto;
	}

	public List<AboutInfoGetDTO> GetAllAboutInfos(Func<AboutInfo, bool>? func = null)
	{
		var Infos = _aboutInfoRepository.GetAll(func);

		List<AboutInfoGetDTO> aboutInfosDto = _mapper.Map<List<AboutInfoGetDTO>>(Infos);
		return aboutInfosDto;
	}

	public void UpdateAboutInfo(AboutInfoUpdateDTO aboutInfoUpdateDTO)
	{
		var existInfo = _aboutInfoRepository.Get(x => x.Id == aboutInfoUpdateDTO.Id);

		if (existInfo == null)
			throw new EntityNotFoundException("Info not found!");

		if (aboutInfoUpdateDTO.ImageFile != null)
		{
			if (aboutInfoUpdateDTO.ImageFile.ContentType != "image/png" && aboutInfoUpdateDTO.ImageFile.ContentType != "image/jpeg")
				throw new ImageContentTypeException("File format is not avialable!");

			Helper.DeleteFile(_env.WebRootPath, @"uploads\aboutinfos", existInfo.ImageUrl);

			existInfo.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\aboutinfos", aboutInfoUpdateDTO.ImageFile);
		}

		if (aboutInfoUpdateDTO.FonImage != null)
		{
			if (aboutInfoUpdateDTO.FonImage.ContentType != "image/png" && aboutInfoUpdateDTO.FonImage.ContentType != "image/jpeg")
				throw new ImageContentTypeException("File format is not avialable!");
			Helper.DeleteFile(_env.WebRootPath, @"uploads\aboutinfos", existInfo.FonUrl);
			existInfo.FonUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\aboutinfos", aboutInfoUpdateDTO.FonImage);
		}




		existInfo.Title = aboutInfoUpdateDTO.Title;
		existInfo.Description = aboutInfoUpdateDTO.Description;

		_aboutInfoRepository.Commit();
	}
}
