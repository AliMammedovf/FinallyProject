using AutoMapper;
using FinalProject.Business.DTOs.SetMenyuHeaderDTOs;
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

public class SetMenyuHeaderService : ISetMenyuHeaderService
{
	private readonly ISetMenyuHeaderRepository _setMenyuHeaderRepository;

	private readonly IMapper _mapper;

	private readonly IWebHostEnvironment _env;

	public SetMenyuHeaderService(ISetMenyuHeaderRepository setMenyuHeaderRepository, IMapper mapper, IWebHostEnvironment env)
	{
		_setMenyuHeaderRepository = setMenyuHeaderRepository;
		_mapper = mapper;
		_env = env;
	}
	public async Task AddSetMenyuHeaderAsync(SetMenyuHeaderCreateDTO setHeaderCreateDTO)
	{
		if (setHeaderCreateDTO.ImageFile == null) throw new EntityNotFoundException("File connot be empty!");

		SetMenyuHeader set = _mapper.Map<SetMenyuHeader>(setHeaderCreateDTO);

		set.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\setmenyu\header", setHeaderCreateDTO.ImageFile);

		await _setMenyuHeaderRepository.AddAsync(set);
		await _setMenyuHeaderRepository.CommitAsync();
	}

	public void DeleteSetMenyuHeader(int id)
	{
		var existSet = _setMenyuHeaderRepository.Get(x => x.Id == id);

		if (existSet == null)
			throw new EntityNotFoundException("Header not found!");

		Helper.DeleteFile(_env.WebRootPath, @"uploads\setmenyu\header", existSet.ImageUrl);

		_setMenyuHeaderRepository.Delete(existSet);
		_setMenyuHeaderRepository.Commit();
	}

	public List<SetMenyuHeaderGetDTO> GetAllSetMenyuHeaders(Func<SetMenyuHeader, bool>? func = null)
	{
		var set = _setMenyuHeaderRepository.GetAll(func);

		List<SetMenyuHeaderGetDTO> setDto = _mapper.Map<List<SetMenyuHeaderGetDTO>>(set);
		return setDto;
	}

	public SetMenyuHeaderGetDTO GetHeaderMenyu(Func<SetMenyuHeader, bool>? func = null)
	{
		var set = _setMenyuHeaderRepository.Get(func);
		SetMenyuHeaderGetDTO setGetDTO = _mapper.Map<SetMenyuHeaderGetDTO>(set);
		return setGetDTO;
	}

	public void UpdateSetMenyuHeader(SetMenyuHeaderUpdateDTO headerUpdateDTO)
	{
		var exsistSet = _setMenyuHeaderRepository.Get(x => x.Id == headerUpdateDTO.Id);

		if (exsistSet == null)
			throw new EntityNotFoundException("Header not found!");

		if (headerUpdateDTO.ImageFile != null)
		{
			if (headerUpdateDTO.ImageFile.ContentType != "image/png" && headerUpdateDTO.ImageFile.ContentType != "image/jpeg")
				throw new ImageContentTypeException("File format is not avialable!");

			Helper.DeleteFile(_env.WebRootPath, @"uploads\setmenyu\header", exsistSet.ImageUrl);

			exsistSet.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\setmenyu\header", headerUpdateDTO.ImageFile);

		}


		exsistSet.Title = headerUpdateDTO.Title;
		exsistSet.Description = headerUpdateDTO.Description;
		

		_setMenyuHeaderRepository.Commit();
	}
}
