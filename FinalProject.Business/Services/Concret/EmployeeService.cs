using AutoMapper;
using FinalProject.Business.DTOs.EmployeeDTOs;
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

public class EmployeeService : IEmployeeService
{
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IWebHostEnvironment _env;
	private readonly IMapper _mapper;

	public EmployeeService(IEmployeeRepository employeeRepository, IWebHostEnvironment env, IMapper mapper)
	{
		_employeeRepository = employeeRepository;
		_env = env;
		_mapper = mapper;
	}

	public async Task AddAsyncEmployee(EmployeeCreateDTO employeeCreateDTO)
	{
		if (employeeCreateDTO.ImageFile == null) throw new EntityNotFoundException("File connot be empty!");

		Employee employee = _mapper.Map<Employee>(employeeCreateDTO);

		employee.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\employees", employeeCreateDTO.ImageFile);

		await _employeeRepository.AddAsync(employee);
		await _employeeRepository.CommitAsync();
	}

	public void DeleteEmployee(int id)
	{
		var existEmployee = _employeeRepository.Get(x => x.Id == id);

		if (existEmployee == null)
			throw new EntityNotFoundException("Employer not found!");

		Helper.DeleteFile(_env.WebRootPath, @"uploads\employees", existEmployee.ImageUrl);

		_employeeRepository.Delete(existEmployee);
		_employeeRepository.Commit();
	}

	public List<EmployeeGetDTO> GetAllEmployees(Func<Employee, bool>? func = null)
	{
		var employee = _employeeRepository.GetAll(func);

		List<EmployeeGetDTO> employeeGetDTOs = _mapper.Map<List<EmployeeGetDTO>>(employee);
		return employeeGetDTOs;
	}

	public EmployeeGetDTO GetEmployee(Func<Employee, bool>? func = null)
	{
		var employee = _employeeRepository.Get(func);
		EmployeeGetDTO employeeGetDTO = _mapper.Map<EmployeeGetDTO>(employee);
		return employeeGetDTO;
	}

	public void UpdateEmployee(EmployeeUpdateDTO employeeUpdateDTO)
	{
		var exsistEmployer = _employeeRepository.Get(x => x.Id == employeeUpdateDTO.Id);

		if (exsistEmployer == null)
			throw new EntityNotFoundException("Employee not found!");

		if (employeeUpdateDTO.ImageFile != null)
		{
			if (employeeUpdateDTO.ImageFile.ContentType != "image/png" && employeeUpdateDTO.ImageFile.ContentType != "image/jpeg")
				throw new ImageContentTypeException("File format is not avialable!");

			Helper.DeleteFile(_env.WebRootPath, @"uploads\sliders", exsistEmployer.ImageUrl);

			exsistEmployer.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\employees", employeeUpdateDTO.ImageFile);

		}


		exsistEmployer.FullName = employeeUpdateDTO.FullName;
		exsistEmployer.Profession = employeeUpdateDTO.Profession;

		_employeeRepository.Commit();
	}
}
