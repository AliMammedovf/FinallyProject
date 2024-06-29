using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.CategoryDTOs;

public class CategoryUpdateDTO
{
    public int Id { get; set; } 
    public string Name { get; set; }
}

public class CategoryUpdateDTOValidator : AbstractValidator<CategoryUpdateDTO>
{
	public CategoryUpdateDTOValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Name cannot be empty!")
			.NotNull().WithMessage("Name cannot be null!")
			.MaximumLength(20).WithMessage("Length should be max 20!");
	}
}
