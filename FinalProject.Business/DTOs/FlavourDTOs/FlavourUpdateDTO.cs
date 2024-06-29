using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.FlavourDTOs;

public class FlavourUpdateDTO
{
    public int Id  { get; set; }
    public string Name { get; set; }
}

public class FlavourUpdateDTOValidator : AbstractValidator<FlavourUpdateDTO>
{
	public FlavourUpdateDTOValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Name cannot be empty!")
			.NotNull().WithMessage("Name cannot be null!")
			.MaximumLength(20).WithMessage("Length should be max 20!");
	}
}
