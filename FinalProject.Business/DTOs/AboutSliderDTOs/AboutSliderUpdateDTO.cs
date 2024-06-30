using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.AboutSliderDTOs;

public class AboutSliderUpdateDTO
{

	public int Id { get; set; }
	public string Title { get; set; } = null!;

	public string? Description { get; set; }

	public string Text { get; set; } = null!;

	public string? ImageUrl { get; set; }

	public string? RedirectUrl { get; set; }

	public IFormFile? ImageFile { get; set; }

	public IFormFile? IconImage { get; set; }
}

public class AboutSliderUpdateDTOValidator : AbstractValidator<AboutSliderUpdateDTO>
{
	public AboutSliderUpdateDTOValidator()
	{
		RuleFor(x => x.Title)
			.NotEmpty().WithMessage("Title cannot be empty!")
			.NotNull().WithMessage("Title cannot be null!")
			.MaximumLength(30).WithMessage("Length should be max 30!");

		RuleFor(x => x.Description)
			.NotEmpty().WithMessage("Description cannot be empty!")
			.NotNull().WithMessage("Description cannot be null!")
			.MaximumLength(50).WithMessage("Length should be max 70!");

		RuleFor(x => x.Text)
			.NotEmpty().WithMessage("Text cannot be empty!")
			.NotNull().WithMessage("Text cannot be null!")
			.MaximumLength(200).WithMessage("Length should be max 200!");

	}
}
