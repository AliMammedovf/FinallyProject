using FinalProject.Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.EmployeeDTOs;

public class EmployeeUpdateDTO
{
	public int Id { get; set; }
	public string FullName { get; set; } = null!;

	public string Profession { get; set; } = null!;

	public string? ImageUrl { get; set; }

	public IFormFile ImageFile { get; set; }
}

public class EmployeeUpdateDTOValidator : AbstractValidator<Employee>
{
	public EmployeeUpdateDTOValidator()
	{
		RuleFor(x => x.FullName)
		   .NotEmpty().WithMessage("FullName cannot be empty!")
		   .NotNull().WithMessage("FullName cannot be null!")
		   .MaximumLength(40).WithMessage("Length should be max 40!");

		RuleFor(x => x.Profession)
		   .NotEmpty().WithMessage("Profession cannot be empty!")
		   .NotNull().WithMessage("Profession cannot be null!")
		   .MaximumLength(30).WithMessage("Length should be max 40!");
	}
}
