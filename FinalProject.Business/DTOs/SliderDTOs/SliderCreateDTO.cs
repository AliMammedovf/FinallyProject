using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.SliderDTOs;

public class SliderCreateDTO
{
	public string Title { get; set; }

	public string Description { get; set; }

	public string? RedirectUrl { get; set; }

	public IFormFile? ImageFile { get; set; }
}

public class SliderCreateDTOValidator: AbstractValidator<SliderCreateDTO>
{
    public SliderCreateDTOValidator()
    {
        RuleFor(x=>x.Title)
			.NotEmpty().WithMessage("Title cannot be empty!")
			.NotNull().WithMessage("Title cannot be null!")
			.MaximumLength(30).WithMessage("Length should be max 30!");

		RuleFor(x=>x.Description)
			.NotEmpty().WithMessage("Description cannot be empty!")
			.NotNull().WithMessage("Description cannot be null!")
			.MaximumLength(70).WithMessage("Length should be max 70!");
		
	}
}
