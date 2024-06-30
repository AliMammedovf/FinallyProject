using AutoMapper;
using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.DTOs.TableDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using FinalProject.Data.RepositoryConcret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Concret;

public class TableService : ITableService
{
	private readonly ITableRepository _tableRepository;
	private readonly IMapper _mapper;

	public TableService(ITableRepository tableRepository, IMapper mapper)
	{
		_tableRepository = tableRepository;
		_mapper = mapper;
	}

	public async Task AddAsyncTable(TableCreateDTO tableCreateDTO)
	{
		if (tableCreateDTO == null)
			throw new EntityNotFoundException("Table not found!");
		Table table = _mapper.Map<Table>(tableCreateDTO);

		if (!_tableRepository.GetAll().Any(x => x.Title == tableCreateDTO.Title))
		{
			 await _tableRepository.AddAsync(table);
			 await _tableRepository.CommitAsync();
		}
		else
		{
			throw new DuplicateEntityException("Table name is available!");
		}

	}

	public void DeleteTable(int id)
	{
		var exsist = _tableRepository.Get(x => x.Id == id);

		if (exsist == null)
			throw new EntityNotFoundException("Id cannot be empty!");

		_tableRepository.Delete(exsist);
		_tableRepository.Commit();
	}

	public IEnumerable<TableGetDTO> GetAllTables(Func<Table, bool>? func = null)
	{
		var table = _tableRepository.GetAll(func);

		List<TableGetDTO> categoryGetDTO = _mapper.Map<List<TableGetDTO>>(table);

		return categoryGetDTO;
	}

	public TableGetDTO GetTable(Func<Table, bool>? func = null)
	{
		var table = _tableRepository.Get(func);

		TableGetDTO tableGetDTO = _mapper.Map<TableGetDTO>(table);

		return tableGetDTO;
	}

	public async Task<bool> IsExistAsync(Expression<Func<Table, bool>> expression)
	{
			return await _tableRepository.IsExistAsync(expression,"Reservation");	
	}

	public void UpdateTable(TableUpdateDTO tableUpdateDTO)
	{
		var oldTable = _tableRepository.Get(x => x.Id == tableUpdateDTO.Id);

		if (oldTable == null)
			throw new EntityNotFoundException("Table not found!");



		if (!_tableRepository.GetAll().Any(x => x.Id != tableUpdateDTO.Id && x.Title == tableUpdateDTO.Title))
		{
			oldTable.Title = tableUpdateDTO.Title;
		}
		else
		{
			throw new DuplicateEntityException("Table name is available!");
		}

		_tableRepository.Commit();
	}
}
