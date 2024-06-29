using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.SizeDTOs;

public class SizeUpdateDTO
{
    public int Id { get; set; } 
    public string Name { get; set; }
}

public class SizeUpdateValidator : AbstractValidator<SizeUpdateDTO>
{
	public SizeUpdateValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Name cannot be empty!")
			.NotNull().WithMessage("Name cannot be null!")
			.MaximumLength(10).WithMessage("Length should be max 10!");
	}
}
