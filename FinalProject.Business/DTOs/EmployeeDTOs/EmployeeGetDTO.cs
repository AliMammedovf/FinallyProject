using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.EmployeeDTOs;

public class EmployeeGetDTO
{
	public int Id { get; set; }
	public string FullName { get; set; } = null!;

	public string Profession { get; set; }=null!;

	public string ImageUrl { get; set; }

	public IFormFile? ImageFile { get; set; }
}
