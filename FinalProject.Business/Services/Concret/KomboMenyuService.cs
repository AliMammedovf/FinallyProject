using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using FinalProject.Data.RepositoryConcret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Concret;

public class KomboMenyuService : IKomboMenyuService
{
	private readonly IKomboMenyuRepository _komboMenyuRepository;

	public KomboMenyuService(IKomboMenyuRepository komboMenyuRepository)
	{
		_komboMenyuRepository = komboMenyuRepository;
	}

	public async Task AddAsyncKomboMenyu(KomboMenyu menyu)
	{
		if (menyu == null)
			throw new EntityNotFoundException("Entity cannot be found!");
		

		if (!_komboMenyuRepository.GetAll().Any(x => x.Title == menyu.Title))
		{
			await _komboMenyuRepository.AddAsync(menyu);
			await _komboMenyuRepository.CommitAsync();
		}
		else
		{
			throw new DuplicateEntityException("Entity name is available!");
		}
	}

	public void DeleteKomboMenyu(int id)
	{
		var exsist = _komboMenyuRepository.Get(x => x.Id == id);

		if (exsist == null)
			throw new EntityNotFoundException("Id cannot be empty!");

		_komboMenyuRepository.Delete(exsist);
		_komboMenyuRepository.Commit();
	}

	public List<KomboMenyu> GetAllMenyus(Func<KomboMenyu, bool>? func = null)
	{
		var menyu = _komboMenyuRepository.GetAll(func);

		return menyu;
	}

	public KomboMenyu GetMenyu(Func<KomboMenyu, bool>? func = null)
	{
		var menyu = _komboMenyuRepository.Get(func);

		return menyu;
	}

	public void UpdateKomboMenyu(KomboMenyu menyu)
	{
		var oldMenyu = _komboMenyuRepository.Get(x => x.Id == menyu.Id);

		if (oldMenyu == null)
			throw new EntityNotFoundException("Entity not found!");



		if (!_komboMenyuRepository.GetAll().Any(x => x.Id != menyu.Id && x.Title == menyu.Title))
		{
			oldMenyu.Title = menyu.Title;
		}
		else
		{
			throw new DuplicateEntityException("Entity name is available!");
		}

		_komboMenyuRepository.Commit();
	}
}
