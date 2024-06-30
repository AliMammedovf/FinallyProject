using FinalProject.Business.DTOs.EmployeeDTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public interface IEmployeeService
{
	Task AddAsyncEmployee(EmployeeCreateDTO employeeCreateDTO);

	void DeleteEmployee(int id);

	void UpdateEmployee(EmployeeUpdateDTO employeeUpdateDTO);

	EmployeeGetDTO GetEmployee(Func<Employee, bool>? func = null);

	List<EmployeeGetDTO> GetAllEmployees(Func<Employee, bool>? func = null);
}
